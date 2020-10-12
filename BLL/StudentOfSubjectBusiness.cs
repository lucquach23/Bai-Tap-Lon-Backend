using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
  public partial  class StudentOfSubjectBusiness : StudentOfSubjectBusinessIF
    {
        private StudentOfSubjectRepositoryIF _res;
        public StudentOfSubjectBusiness(StudentOfSubjectRepositoryIF cos)
        {
            _res = cos;
        }
        public List<StudentOfSubject> GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
