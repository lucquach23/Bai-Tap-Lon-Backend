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
    public class ClassRegistionController : ControllerBase
    {
        private ClassOfStudentBusinessIF _classOfStudent;
        private StudentOfSubjectBusinessIF _studentOfSubjectClass;
        private ListSubjectClassBusinessIF _listSubjectClass;
        public ClassRegistionController(
            ClassOfStudentBusinessIF a, 
            StudentOfSubjectBusinessIF b, 
            ListSubjectClassBusinessIF c
            )
        {
            _classOfStudent = a;
            _studentOfSubjectClass = b;
            _listSubjectClass = c;
        }
        [Route("getClassOfStudentById/{id}")]
        // api lấy danh sách các lớp mà sinh viên đã đăng kí học theo mã sinh viên
        [HttpGet]
        public List<ClassOfStudent> getClassOfStudentById(string id)
        {
            return _classOfStudent.GetDatabyID(id);
        }

        // api lấy danh sách các sinh viên trong lớp 
        //mà giảng viên đã đăng kí giảng dạy môn đó theo mã giảng viên
        [Route("getListStudentInSubjectClass/{id}")]
        [HttpGet]
        public List<StudentOfSubject> getListStudentInSubjectClass(string id)
        {
            return _studentOfSubjectClass.GetDatabyID(id);
        }

        //lấy danh sách học phần có số sinh viên đăng kí lớp đó
        [Route("getListSubjectClass")]
        [HttpGet]
        public List<ListSubjectClass> getListSubjectClass()
        {
            return _listSubjectClass.GetData();
        }
    }
}
