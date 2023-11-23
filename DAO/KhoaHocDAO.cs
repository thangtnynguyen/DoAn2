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

        private IDatabaseHelper _dbHelper;
        public KhoaHocDAO(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(KhoaHocModel model)
        {



            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ThemKhoaHoc_Chuong",
                 "@Ten", model.Ten,
                 "@Loai", model.LoaiId,
                 "@HinhAnh", model.HinhAnh,
                 "@TacGia", model.TacGiaId,
                 "@Gia", model.Gia,
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
            throw new NotImplementedException();
        }

        public List<KhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten_khoa, string loai_khoa)
        {
            throw new NotImplementedException();
        }

        public bool Update(KhoaHocModel model)
        {
            throw new NotImplementedException();
        }
    }
}
