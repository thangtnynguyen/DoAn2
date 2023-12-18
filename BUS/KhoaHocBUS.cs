using BUS.Interfaces;
using DAO.Interfaces;
using DataModel.Common;
using DataModel.KhoaHoc;
using System.Reflection;

namespace BUS
{
    public class KhoaHocBUS : IKhoaHocBUS
    {
        private IKhoaHocDAO _khoaHocDAO;
        public KhoaHocBUS(IKhoaHocDAO res)
        {
            _khoaHocDAO = res;
        }
        public bool Create(KhoaHocModel model)
        {
            return _khoaHocDAO.Create(model);
        }
        public KhoaHocModel GetDatabyID(string id)
        {
            KhoaHocModel result = _khoaHocDAO.GetDatabyID(id);

            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.HinhAnh))
                {
                    result.HinhAnh = SystemConfig.BaseUrl + result.HinhAnh;
                }
            }
            return result;
        }

      

        public PagingResult<KhoaHocModel> Search(GetKhoaHocRequest getKhoaHocRequest)
        {
            PagingResult<KhoaHocModel> result = _khoaHocDAO.Search(getKhoaHocRequest);

            if (result != null && result.Items != null && result.Items.Any())
            {
                foreach (var khoaHocModel in result.Items)
                {
                    if (!string.IsNullOrEmpty(khoaHocModel.HinhAnh))
                    {
                        khoaHocModel.HinhAnh = SystemConfig.BaseUrl + khoaHocModel.HinhAnh;
                    }
                }
            }

            return result;
        }


        public bool Update(KhoaHocModel model)
        {
            return _khoaHocDAO.Update(model);
        }
        public List<KhoaHocModel> SearchAll()
        {
            //return _khoaHocDAO.SearchAll();
            List<KhoaHocModel> result = _khoaHocDAO.SearchAll();

            if (result != null && result.Any())
            {
                foreach (var khoaHocModel in result)
                {
                    if (!string.IsNullOrEmpty(khoaHocModel.HinhAnh))
                    {
                        khoaHocModel.HinhAnh = SystemConfig.BaseUrl + khoaHocModel.HinhAnh;
                    }
                }
            }
            return result;
        }
        public bool Delete(KhoaHocDelete khoaHocDelete)
        {
            return _khoaHocDAO.Delete(khoaHocDelete);
        }
        public bool DeleteMultiple(List<KhoaHocDelete> khoaHocDeletes)
        {
            return _khoaHocDAO.DeleteMultiple(khoaHocDeletes);
        }


    }
}