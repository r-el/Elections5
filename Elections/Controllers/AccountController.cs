using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Elections.Data;
using Elections.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Voter>> Register(string phoneID, string fullName, string mail, string password)
        {
            // Check if the voter exists
            if (await VoterExists(phoneID)) return BadRequest("The voter is already registered");

            // Check if the fields are valid
            if (await PhoneNotValid(phoneID)) return BadRequest("מספר טלפון חייב להיות בעל 10 ספרות");
            if (await NameNotValid(fullName)) return BadRequest("לא הוזן שם מלא");
            if (await MailNotValid(mail)) return BadRequest("כתובת מייל לא תקינה");
            if (await PasswordNotValid(password)) return BadRequest("סיסמא חייבת להיות עם מספרים ואותיות, בין 8 ל-20 ספרות");

            using var hmac = new HMACSHA512();

            var voter = new Voter
            {
                PhoneID = phoneID,
                FullName = fullName,
                Mail = mail,
                Password = password,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key // Random text
            };

            _context.Voters.Add(voter); // EF tracking
            await _context.SaveChangesAsync(); // Save to the db

            return voter;

        }

        // Check if voter exists(by phoneID)
        private async Task<bool> VoterExists(string phoneID)
        {
            return await _context.Voters.AnyAsync(x => x.PhoneID == phoneID);
        }

        // Check if the fields are valid
        private async Task<bool> PhoneNotValid(string phoneID) { return (phoneID != null) && !(phoneID.Length == 10); }
        private async Task<bool> NameNotValid(string fullName) { return (fullName != null) && !(fullName.Length > 4); }
        private async Task<bool> MailNotValid(string mail) { return (mail != null) && !(new EmailAddressAttribute().IsValid(mail)); }
        private async Task<bool> PasswordNotValid(string password)
        {
            Regex rgxPswd = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,20})$");

            return (password != null) && !(rgxPswd.IsMatch(password));
        }
}
}