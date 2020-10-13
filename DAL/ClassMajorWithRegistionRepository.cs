using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
    public partial class ClassMajorWithRegistionRepository : ClassMajorWithRegistionRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public ClassMajorWithRegistionRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<ClassMajorWithRegistion> GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListClassMajor",
                     "@IdClassMajor", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ClassMajorWithRegistion>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
