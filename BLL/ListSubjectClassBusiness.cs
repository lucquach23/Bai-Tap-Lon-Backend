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
  public partial  class ListSubjectClassBusiness : ListSubjectClassBusinessIF
    {
        private ListSubjectClassRepositoryIF _res;
        public ListSubjectClassBusiness(ListSubjectClassRepositoryIF cos)
        {
            _res = cos;
        }
        public List<ListSubjectClass> GetData()
        {
            return _res.GetData();
        }
    }
}
