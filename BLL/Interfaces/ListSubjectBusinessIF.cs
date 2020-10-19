using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ListSubjectBusinessIF
    {
        List<ListSubject> GetListSubject(string id_faculty);
    }
}
