using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface StudentOfSubjectRepositoryIF
    {
        List<StudentOfSubject> GetDatabyID(string id);
    }
}
