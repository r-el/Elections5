
using Elections.Interfaces;
using Elections.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key; // _key used to encrypt and decrypt electronic information (used to both side JWT token).
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(Voter voter)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, voter.PhoneID) // בינתיים הקליים היחיד
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // SecurityKey & Algorithm

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7), // (דרישות פרוייקט גמר, זה עד שעה)
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
