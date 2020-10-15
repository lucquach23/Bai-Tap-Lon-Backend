using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
   public partial class ClassOfStudentRepository : ClassOfStudentRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public ClassOfStudentRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<ClassOfStudent> GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getSubjectRegisterbyIdStudent",
                     "@IdStudent", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ClassOfStudent>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteCO(string id_cr,string id_student)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "deleteClassOpen",
                "@id_cr", id_cr,
                "@id_stud",id_student);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
