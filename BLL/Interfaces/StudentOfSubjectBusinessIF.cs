using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface StudentOfSubjectBusinessIF
    {
        List<StudentOfSubject> GetDatabyID(string id);
    }
}
