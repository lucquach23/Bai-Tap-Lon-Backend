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
    public class ClassRegistersController : ControllerBase
    {
        private readonly RegisterSubjectDBContext _context;

        public ClassRegistersController(RegisterSubjectDBContext context)
        {
            _context = context;
        }

        // GET: api/ClassRegisters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRegister>>> GetClassRegisters()
        {
            return await _context.ClassRegisters.ToListAsync();
        }

        // GET: api/ClassRegisters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassRegister>> GetClassRegister(string id)
        {
            var classRegister = await _context.ClassRegisters.FindAsync(id);

            if (classRegister == null)
            {
                return NotFound();
            }

            return classRegister;
        }


        [Route("layLopGvDaDangKi/{id_gv}")]
        [HttpGet]
        public List<ClassRegister> getInfoGv(string id_gv)
        {
            return _context.ClassRegisters.Include(x=>x.IdSubjectNavigation)
                .Where(x => x.IdLecturers == id_gv).ToList();
        }
        //[Route("laydsloptheomakhoa/{id_khoa}")]
        //[HttpGet]
        //public List<ClassRegister> dsClassOpen(string id_khoa)
        //{
        //    return _context.ClassRegisters.Include(x=>x.)
        //        .Where(x => x.IdSubject == id_khoa).ToList();
        //}


        [Route("removeAll/{id_gv}")]
        [HttpDelete]
        public void RemoveAll(string id_gv)
        {
            using (RegisterSubjectDBContext db = new RegisterSubjectDBContext())
            {
                List<ClassRegister> s = db.ClassRegisters.Where(x => x.IdLecturers == id_gv).ToList();
                db.ClassRegisters.RemoveRange(s);
                db.SaveChanges();
            }
        }






        // PUT: api/ClassRegisters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassRegister(string id, ClassRegister classRegister)
        {
            if (id != classRegister.IdClassRegister)
            {
                return BadRequest();
            }

            _context.Entry(classRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRegisterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClassRegisters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClassRegister>> PostClassRegister(ClassRegister classRegister)
        {
            _context.ClassRegisters.Add(classRegister);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassRegisterExists(classRegister.IdClassRegister))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClassRegister", new { id = classRegister.IdClassRegister }, classRegister);
        }

        // DELETE: api/ClassRegisters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassRegister>> DeleteClassRegister(string id)
        {
            var classRegister = await _context.ClassRegisters.FindAsync(id);
            if (classRegister == null)
            {
                return NotFound();
            }

            _context.ClassRegisters.Remove(classRegister);
            await _context.SaveChangesAsync();

            return classRegister;
        }


        private bool ClassRegisterExists(string id)
        {
            return _context.ClassRegisters.Any(e => e.IdClassRegister == id);
        }
    }
}
