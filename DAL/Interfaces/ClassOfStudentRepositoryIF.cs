﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ClassOfStudentRepositoryIF
    {
        List<ClassOfStudent> GetDatabyID(string id);
    }
}