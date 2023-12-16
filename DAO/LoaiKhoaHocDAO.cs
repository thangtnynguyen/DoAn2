using DAO.Helper;
using DAO.Helper.Interfaces;
using DAO.Interfaces;
using DataModel.LoaiKhoaHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LoaiKhoaHocDAO : ILoaiKhoaHocDAO
    {
        private ITruyVanDuLieu _truyvan;
        public LoaiKhoaHocDAO(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public List<LoaiKhoaHocModel> SearchAll()
        {
            string msgError = "";
            try
            {
                string query = "SELECT *  FROM LoaiKhoaHoc";
                var dt = _truyvan.ExecuteQueryToDataTable(query, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiKhoaHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
