
using Elections.Interfaces;
using Elections.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }
    }
}
