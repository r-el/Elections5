using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Voter voter);
    }
}
