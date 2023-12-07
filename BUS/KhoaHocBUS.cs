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
            return _khoaHocDAO.GetDatabyID(id);
        }

        //public List<KhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten_khoa)
        //{
        //    return _khoaHocDAO.Search(pageIndex, pageSize, out total, ten_khoa);
        //}
        public PagingResult<KhoaHocModel> Search(GetKhoaHocRequest getKhoaHocRequest)
        {
            return _khoaHocDAO.Search(getKhoaHocRequest);

        }

        public bool Update(KhoaHocModel model)
        {
            return _khoaHocDAO.Update(model);
        }
        public List<KhoaHocModel> SearchAll()
        {
            return _khoaHocDAO.SearchAll();
        }
        public bool Delete(KhoaHocDelete khoaHocDelete)
        {
            return _khoaHocDAO.Delete(khoaHocDelete);
        }

    }
}