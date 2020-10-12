using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
   public partial class ListSubjectClassRepository : ListSubjectClassRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public ListSubjectClassRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<ListSubjectClass> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListSubjectWithQuantityStudent");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ListSubjectClass>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
