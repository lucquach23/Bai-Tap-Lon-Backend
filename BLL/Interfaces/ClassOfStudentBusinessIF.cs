﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ClassOfStudentBusinessIF
    {
        List<ClassOfStudent> GetDatabyID(string id);
    }
}