using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly RegisterSubjectDBContext _context;

        public AccountsController(RegisterSubjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

      

        [Route("getAccByUserName/{username}")]
        [HttpGet]
        public List<Student> getAccByUserName(string username)
        {
            return _context.Students.Where(x => x.IdStudent == username).ToList();
        }

        [Route("getInfoGv/{username}")]
        [HttpGet]
        public List<Lecturer> getInfoGv(string username)
        {
            return _context.Lecturers
                           .Include(x=>x.IdDepartmentNavigation)
                            .ThenInclude(x=>x.IdFacultyNavigation)
                           .Where(x => x.IdLecturers == username).ToList();
        }





    }
}
