using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Formatting;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListCrsController : ControllerBase
    {
        private readonly RegisterSubjectDBContext _context;

        public ListCrsController(RegisterSubjectDBContext context)
        {
            _context = context;
        }

        // GET: api/ListCrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListCr>>> GetListCrs()
        {
            return await _context.ListCrs.ToListAsync();
        }

        // GET: api/ListCrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListCr>> GetListCr(int id)
        {
            var listCr = await _context.ListCrs.FindAsync(id);

            if (listCr == null)
            {
                return NotFound();
            }

            return listCr;
        }

        // PUT: api/ListCrs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListCr(int id, ListCr listCr)
        {
            if (id != listCr.IdCr)
            {
                return BadRequest();
            }

            _context.Entry(listCr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListCrExists(id))
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

        // POST: api/ListCrs
        [HttpPost]
        public async Task<ActionResult<ListCr>> PostListCr(ListCr listCr)
        {
            _context.ListCrs.Add(listCr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListCr", new { id = listCr.IdCr }, listCr);
        }

        // DELETE: api/ListCrs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListCr>> DeleteListCr(int id)
        {
            var listCr = await _context.ListCrs.FindAsync(id);
            if (listCr == null)
            {
                return NotFound();
            }

            _context.ListCrs.Remove(listCr);
            await _context.SaveChangesAsync();

            return listCr;
        }

        [Route("removeCO/{id_cr}/{id_student}")]
        [HttpDelete]
        public void Remove(string id_cr,string id_student)
        {                                          
            using (RegisterSubjectDBContext db = new RegisterSubjectDBContext())
                    {
                        ListCr s = db.ListCrs.SingleOrDefault(x => x.IdClassRegister == id_cr&&x.IdStudent==id_student);
                        db.ListCrs.Remove(s);
                        db.SaveChanges();
                    }
        }
        [Route("removeAll/{id_student}")]
        [HttpDelete]
        public void RemoveAll(string id_student)
        {
            using (RegisterSubjectDBContext db = new RegisterSubjectDBContext())
            {
                List<ListCr> s = db.ListCrs.Where(x => x.IdStudent == id_student).ToList();
                db.ListCrs.RemoveRange(s);
                db.SaveChanges();
            }
        }


        private bool ListCrExists(int id)
        {
            return _context.ListCrs.Any(e => e.IdCr == id);
        }
    }
}
