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
  public partial  class ClassOfStudentBusiness : ClassOfStudentBusinessIF
    {
        private ClassOfStudentRepositoryIF _res;
        public ClassOfStudentBusiness(ClassOfStudentRepositoryIF cos)
        {
            _res = cos;
        }
        public ClassOfStudent GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
