using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
   public partial class ListSubjectRepository : ListSubjectRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public ListSubjectRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<ListSubject> GetListSubject(string id_faculty)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListSubject", "@id_faculty",id_faculty);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ListSubject>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<gv> get2infogv(string id_faculty)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListGvByFaculty", "@id_faculty", id_faculty);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<gv>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClassOpenByIdFaculty> getListClassOpenByIdFaculty(string id_faculty)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getClassOpenByIdFaculty", "@id_faculty", id_faculty);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ClassOpenByIdFaculty>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClassOpenByIdFaculty> getListClassOpenByIdgv(string id_gv)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_co_by_magv", "@ma_gv", id_gv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ClassOpenByIdFaculty>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
