using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ClassOfStudentRepositoryIF
    {
        List<ClassOfStudent> GetDatabyID(string id);
        bool DeleteCO(string id_cr, string id_student);
    }
}
