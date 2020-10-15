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
        private ClassMajorWithRegistionBusinessIF _classMajorWithRegistion;
        public ClassRegistionController(
            ClassOfStudentBusinessIF a,
            StudentOfSubjectBusinessIF b,
            ListSubjectClassBusinessIF c,
            ClassMajorWithRegistionBusinessIF d
            )
        {
            _classOfStudent = a;
            _studentOfSubjectClass = b;
            _listSubjectClass = c;
            _classMajorWithRegistion = d;
        }





        // api lấy danh sách các lớp mà sinh viên đã đăng kí học theo mã sinh viên
        [Route("getClassOfStudentById/{id}")]
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


        //api lấy về danh sách lớp chuyên ngành cùng với số lượng đăng kí , và tổng số tín chỉ
        [Route("getListClassMajorWithRegistionByIdClassMajor/{id}")]
        [HttpGet]
        public List<ClassMajorWithRegistion> getListClassMajorWithRegistionByIdClassMajor(string id)
        {
            return _classMajorWithRegistion.GetDatabyID(id);


        }
        [Route("deleteCO")]
        [HttpDelete]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string id_cr = "";
            string id_student = "";
            if (formData.Keys.Contains("id_cr") && !string.IsNullOrEmpty(Convert.ToString(formData["id_cr"])))
            {
                id_cr = Convert.ToString(formData["id_cr"]);
            }
            if (formData.Keys.Contains("id_student") && !string.IsNullOrEmpty(Convert.ToString(formData["id_student"])))
            {
                id_student = Convert.ToString(formData["id_student"]);
            }
            _classOfStudent.DeleteCO(id_cr,id_student);
            return Ok();
        }
    }
}
