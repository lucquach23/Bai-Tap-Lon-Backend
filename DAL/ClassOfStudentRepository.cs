﻿using DAL.Helper;
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
        public List<sv_hp> getListSVbyIdhp(string id_hp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListStudentRegisterSubjectByIdLecturer",
                     "@id_hp", id_hp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<sv_hp>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<class_major> get_list_class_major(string id_class)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getListClassMajor",
                     "@IdClassMajor", id_class);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<class_major>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public List<lop_bm> getlop_bm(string id_faculty)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_class_major_by_id_faculty",
                     "@id", id_faculty);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<lop_bm>().ToList();
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
