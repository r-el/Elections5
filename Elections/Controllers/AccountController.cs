using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Elections.Data;
using Elections.Interfaces;
using Elections.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Voter>> Login(string phoneID, string password)
        {
            // וודא תקינות ערכים
            if (phoneID == string.Empty || password == string.Empty) return BadRequest("One or more fields are empty"); // Check if not null
            if (await PhoneNotValid(phoneID)) return BadRequest("מספר טלפון חייב להיות בעל 10 ספרות");

            var voter = await _context.Voters
                .SingleOrDefaultAsync(x => x.PhoneID == phoneID); // Get the Voter from the DB by phoneID

            if (voter == null) return Unauthorized("Invalid username"); // Check if voter exists in DB

            using var hmac = new HMACSHA512(voter.PasswordSalt); // Use in the second HMACSHA512 ctor, (passing the key, and no generatekey)

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Check if the passwords match
            // loop over each element in the array byte
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != voter.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return voter;
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