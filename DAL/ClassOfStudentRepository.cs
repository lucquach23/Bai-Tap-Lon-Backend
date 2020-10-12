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
        public ClassOfStudent GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getSubjectRegisterbyIdStudent",
                     "@IdStudent", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ClassOfStudent>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
