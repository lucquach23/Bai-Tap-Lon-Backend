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
  public partial  class ClassMajorWithRegistionBusiness : ClassMajorWithRegistionBusinessIF
    {
        private ClassMajorWithRegistionRepositoryIF _res;
        public ClassMajorWithRegistionBusiness(ClassMajorWithRegistionRepositoryIF cos)
        {
            _res = cos;
        }
        public List<ClassMajorWithRegistion> GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
