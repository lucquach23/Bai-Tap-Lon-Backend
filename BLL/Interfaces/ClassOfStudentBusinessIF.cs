using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ClassOfStudentBusinessIF
    {
        List<ClassOfStudent> GetDatabyID(string id);
        bool DeleteCO(string id_cr, string id_student);
        List<sv_hp> getListSVbyIdhp(string id_hp);
        List<lop_bm> getlop_bm(string id_faculty);
        List<class_major> get_list_class_major(string id_class);
    }
}
