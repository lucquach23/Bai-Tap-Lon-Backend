using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ListSubjectClassRepositoryIF
    {
        List<ListSubjectClass> GetData();
    }
}
