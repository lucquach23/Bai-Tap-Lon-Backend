using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ListSubjectRepositoryIF
    {
        List<ListSubject> GetListSubject(string id_faculty);
    }
}
