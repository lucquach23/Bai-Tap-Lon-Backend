using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
   public partial class StudentOfSubjectRepository : StudentOfSubjectRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public StudentOfSubjectRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<StudentOfSubject> GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListStudentRegisterSubjectByIdLecturer",
                     "@IdLecturer", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<StudentOfSubject>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
