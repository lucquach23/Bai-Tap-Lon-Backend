using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacutyController : ControllerBase
    {
       [HttpGet]
       [Route("/GetListFacuty")]
        //get all facuty
        public IEnumerable<Faculty> GetListFacuty()
        {
            using(var context=new RegisterSubjectDBContext())
            {
               return context.Faculty.ToList();
            }
        }
        [HttpGet]
        [Route("/GetFacultyById/{id?}")]
        //get facuty by id 
        public IEnumerable<Faculty> GetFacultyById(string id)
        {
            using (var context = new RegisterSubjectDBContext())
            {
                return context.Faculty.Where(x => x.IdFaculty == id).ToList();
            }
        }
    }
}
