using DAO.Helper.Interfaces;
using DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Helper.Interfaces;
using System.Runtime.InteropServices;
using DAO.Helper;
using DataModel.User;
using DataModel.KhoaHoc;
using System.Reflection;
using DataModel.Common;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

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
                object[] parameters = new object[] { "@Ten", model.Ten, "@HinhAnh", model.HinhAnh, "@MoTa", model.MoTa, "@VideoGioiThieu", model.VideoGioiThieu, "@TacGia", model.TacGiaId, "@Loai", model.LoaiId, "@Gia", model.Gia, "@TrangThai", model.TrangThai, "@chuongModels", model.chuongModels != null ? MessageConvert.SerializeObject(model.chuongModels) : null };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ThemKhoaHoc_Chuong_BaiHoc", parameters);
                 
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

        public bool Delete(KhoaHocDelete khoaHocDelete)
        {
            try
            {
                object[] parameters = new object[] { "@Id", khoaHocDelete.Id };
                var loi = _truyvan.ExecuteSProcedureNonQuery("sp_XoaKhoaHoc", parameters);
                if (loi.ToString()=="")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
        public bool DeleteMultiple(List<KhoaHocDelete> khoaHocDeletes)
        {
            try
            {
              
                object[] parameters = new object[] { "@IdsJson", khoaHocDeletes  != null ? MessageConvert.SerializeObject(khoaHocDeletes) : null };
                var result = _truyvan.ExecuteSProcedureNonQuery("sp_XoaNhieuKhoaHoc", parameters);

                if (result != null && result.ToString() == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
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
        //public List<KhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten_khoa)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemKhoaHoc",
        //        "@page_index", pageIndex,
        //        "@page_size", pageSize,
        //        "@ten_khoa", ten_khoa);
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<KhoaHocModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public PagingResult<KhoaHocModel> Search(GetKhoaHocRequest getKhoaHocRequest)
        {
            string msgError = "";
            //total = 0;
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemKhoaHoc",
                "@page_index", getKhoaHocRequest.PageIndex,
                "@page_size", getKhoaHocRequest.PageSize,
                "@ten_khoa", getKhoaHocRequest.Ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                if (dt.Rows.Count > 0)
                {
                    long TotalPages_pre = (long)dt.Rows[0]["RecordCount"] / ((int)getKhoaHocRequest.PageSize);
                    if ((long)dt.Rows[0]["RecordCount"] % ((int)getKhoaHocRequest.PageSize) != 0)
                    {
                        TotalPages_pre++;
                    }
                    return new PagingResult<KhoaHocModel>()
                    {
                        Items = dt.ConvertTo<KhoaHocModel>().ToList(),
                        PageIndex = (int)getKhoaHocRequest.PageIndex,
                        PageSize = (int)getKhoaHocRequest.PageSize,
                        TotalRecords = (long)dt.Rows[0]["RecordCount"],
                        TotalPages = TotalPages_pre,
                        //(long)dt.Rows[0]["RecordCount"] / ((int)getKhoaHocRequest.PageSize) + 1
                    };
                }
                else
                {
                    return new PagingResult<KhoaHocModel>()
                    {
                        Items = null,
                        PageIndex = 0,
                        PageSize =0,
                        TotalRecords = 0,
                        TotalPages = 0,
                    };
                }
                

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
        public List<KhoaHocModel> SearchAll()
        {
            string msgError = "";
            try
            {
                string query = "SELECT *  FROM KhoaHoc WHERE DeleteAt is null";
                var dt = _truyvan.ExecuteQueryToDataTable(query, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhoaHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
