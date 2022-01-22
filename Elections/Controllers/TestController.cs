using Elections.Data;
using Elections.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers
{
    public class TestController : BaseApiController
    {
        // גישה לדטאבייס פרטית
        private readonly DataContext _context;
        public TestController(DataContext context) // אינג'קשיין לקונקשיין סטרינג
        {
            _context = context;
        }

        //---------------------------------------- Voter Routes --------------------------------------//
        //// @route  GET 
        //// @desc   Get All Managers
        //// @access Public
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Manager>>> GetAllManagers()
        //{// תחזיר לקליינט את כל המשתמשים מהדטאבייס
        //    return await _context.Managers.ToListAsync(); // || _context.Users.ToListAsync().;
        //}

        //// @route  GET /api/test/{id}
        //// @desc   Find Voter by PhoneID
        //// @access Public
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Manager>> GetVoter(int id)
        //{// תחזיר לקליינט את המשתמש הרצוי
        //    return await _context.Managers.FindAsync(id);
        //}
        //---------------------------------------- End Voter Routes ----------------------------------//

        //---------------------------------------- Voter Routes --------------------------------------//
        // @route  GET /api/test
        // @desc   Get All Registers Voters
        // @access Public
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Voter>>> GetAllVoters()
        {// תחזיר לקליינט את כל המשתמשים מהדטאבייס
            return await _context.Voters.ToListAsync(); // || _context.Users.ToListAsync().;
        }

        // @route  GET /api/test/{PhoneID}
        // @desc   Find Voter by PhoneID
        // @access Public
        [HttpGet("{id}")]
        public async Task<ActionResult<Voter>> GetVoter(string id)
        {// תחזיר לקליינט את המשתמש הרצוי
            return await _context.Voters.FindAsync(id);
        }
        //---------------------------------------- End Voter Routes ----------------------------------//

    }
}
