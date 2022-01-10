using Elections.Data;
using Elections.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // גישה לדטאבייס פרטית
        private readonly DataContext _context;
        public TestController(DataContext context) // אינג'קשיין לקונקשיין סטרינג
        {
            _context = context;
        }

        // api/users
        // @route  GET /api/test
        // @desc   Get All Registers Voters
        // @access Public
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetAllVoters()
        {// תחזיר לקליינט את כל המשתמשים מהדטאבייס
            return await _context.Voters.ToListAsync(); // || _context.Users.ToListAsync().;
        }

        // @route  GET /api/test/{id}
        // @desc   Find Voter by PhoneID
        // @access Public
        [HttpGet("{id}")]
        public async Task<ActionResult<Voter>> GetVoter(string id)
        {// תחזיר לקליינט את המשתמש הרצוי
            return await _context.Voters.FindAsync(id);
        }
    }
}
