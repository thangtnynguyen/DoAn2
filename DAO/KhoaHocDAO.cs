using DAO.Helper.Interfaces;
using DAO.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Helper.Interfaces;
using System.Runtime.InteropServices;
using DAO.Helper;

namespace DAO
{
    public class KhoaHocDAO : IKhoaHocDAO
    {

        private ITruyVanDuLieu _truyvan;
        public KhoaHocDAO(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public bool Create(KhoaHocModel model)
        {


            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ThemKhoaHoc_Chuong",
                 "@Ten", model.Ten,
                 "@Loai", model.LoaiId,
                 "@HinhAnh", model.HinhAnh,
                 "@TacGia", model.TacGiaId,
                 "@Gia", model.Gia,
                 "@VideoGioiThieu", model.VideoGioiThieu,
                 "@chuongModels", model.chuongModels != null ? MessageConvert.SerializeObject(model.chuongModels) : null,
                 "CreateAt",model.CreateAt,
                 "UpdateAt",model.UpdateAt
                 );

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

        public bool Delete(KhoaHocModel model)
        {
            throw new NotImplementedException();
            
        }

        public KhoaHocModel GetDatabyID(string id)
        {

            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "sp_LayKhoaHocById",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhoaHocModel>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
                
            }

        }

        public List<KhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten_khoa)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemKhoaHoc",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_khoa", ten_khoa);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhoaHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Update(KhoaHocModel model)
        {

            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SuaKhoaHoc_Chuong",
                "@Id", model.Id,
                "@Ten", model.Ten,
                "@Loai", model.LoaiId,
                "@HinhAnh", model.HinhAnh,
                "@TacGia", model.TacGiaId,
                "@Gia", model.Gia,
                "@VideoGioiThieu",model.VideoGioiThieu,
                "@chuongModels", model.chuongModels != null ? MessageConvert.SerializeObject(model.chuongModels) : null,
                "CreateAt", model.CreateAt,
                "UpdateAt", model.UpdateAt);
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
