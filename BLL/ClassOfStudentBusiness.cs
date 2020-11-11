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
        public List<lop_bm> getlop_bm(string id_faculty)
        {
            return _res.getlop_bm(id_faculty);
        }
        public List<class_major> get_list_class_major(string id_class)
        {
            return _res.get_list_class_major(id_class);
        }
        public List<sv_hp> getListSVbyIdhp(string id_hp)
        {
            return _res.getListSVbyIdhp(id_hp);
        }
        public List<ClassOfStudent> GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool DeleteCO(string id_cr,string id_student)
        {
            return _res.DeleteCO(id_cr, id_student);
        }
    }
}
