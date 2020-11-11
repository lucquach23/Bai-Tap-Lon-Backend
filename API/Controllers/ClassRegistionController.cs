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
        private ListSubjectBusinessIF _listSubject;
        public ClassRegistionController(
            ClassOfStudentBusinessIF a,
            StudentOfSubjectBusinessIF b,
            ListSubjectClassBusinessIF c,
            ClassMajorWithRegistionBusinessIF d,
            ListSubjectBusinessIF e
            )
        {
            _classOfStudent = a;
            _studentOfSubjectClass = b;
            _listSubjectClass = c;
            _classMajorWithRegistion = d;
            _listSubject = e;
        }
        [Route("get2infogv/{id_faculty}")]
        [HttpGet]
        public List<gv> get2infogv(string id_faculty)
        {
            return _listSubject.get2infogv(id_faculty);
        }
        // api lấy danh sách các lớp mà sinh viên đã đăng kí học theo mã sinh viên
        [Route("getClassOfStudentById/{id}")]
        [HttpGet]
        public List<ClassOfStudent> getClassOfStudentById(string id)
        {
            return _classOfStudent.GetDatabyID(id);
        }

        [Route("laysvtheomahp/{id_hp}")]
        [HttpGet]
        public List<sv_hp> getsvbymahp(string id_hp)
        {
            return _classOfStudent.getListSVbyIdhp(id_hp);
        }
        [Route("getClassMajorByIdClass/{id_class}")]
        [HttpGet]
        public List<class_major> getClassMajorByIdClass(string id_class)
        {
            return _classOfStudent.get_list_class_major(id_class);
        }
        [Route("classMajorByFaculty/{id_faculty}")]
        [HttpGet]
        public List<lop_bm> getClassMajorByFaculty(string id_faculty)
        {
            return _classOfStudent.getlop_bm(id_faculty);
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
        [Route("getListSubject/{id_faculty}")]
        [HttpGet]
        public List<ListSubject> listSubject(string id_faculty)
        {
            return _listSubject.GetListSubject(id_faculty);
        }
        [Route("getListClassOpenByIdFaculty/{id_faculty}")]
        [HttpGet]
        public List<ClassOpenByIdFaculty> ListClassOpenByIdFaculty(string id_faculty)
        {
            return _listSubject.getListClassOpenByIdFaculty(id_faculty);
        }
        [Route("getListClassOpenByIdgv/{id_gv}")]
        [HttpGet]
        public List<ClassOpenByIdFaculty> ListClassOpenByIdgv(string id_gv)
        {
            return _listSubject.getListClassOpenByIdgv(id_gv);
        }
    }
}
