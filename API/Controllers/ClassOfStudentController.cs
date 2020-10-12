using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassOfStudentController : ControllerBase
    {
        private ClassOfStudentBusinessIF _item;
        public ClassOfStudentController(ClassOfStudentBusinessIF item)
        {
            _item = item;
        }
        //[Route("getClassOfStudentById/{id}")]
        [HttpGet]
        public ClassOfStudent getClassOfStudentById(string id)
        {
            return _item.GetDatabyID(id);
        }
    }
}
