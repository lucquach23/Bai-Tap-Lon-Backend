using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ListSubjectRepositoryIF
    {
        List<ListSubject> GetListSubject(string id_faculty);
        List<ClassOpenByIdFaculty> getListClassOpenByIdFaculty(string id_faculty);
        List<gv> get2infogv(string id_faculty);
        List<ClassOpenByIdFaculty> getListClassOpenByIdgv(string id_gv);
    }
}
