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
  public partial  class ListSubjectBusiness : ListSubjectBusinessIF
    {
        private ListSubjectRepositoryIF _res;
        public ListSubjectBusiness(ListSubjectRepositoryIF cos)
        {
            _res = cos;
        }
        public List<ListSubject> GetListSubject(string id_faculty)
        {
            return _res.GetListSubject(id_faculty);
        }
    }
}
