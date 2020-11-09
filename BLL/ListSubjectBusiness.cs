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
       public List<ClassOpenByIdFaculty> getListClassOpenByIdFaculty(string id_faculty)
        {
            return _res.getListClassOpenByIdFaculty(id_faculty);
        }
        public List<gv> get2infogv(string id_faculty)
        {
            return _res.get2infogv(id_faculty);
        }
        public List<ClassOpenByIdFaculty> getListClassOpenByIdgv(string id_gv)
        {
            return _res.getListClassOpenByIdgv(id_gv);
        }
    }
}
