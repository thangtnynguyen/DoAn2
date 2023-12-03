using BUS.Interfaces;
using DAO.Interfaces;
using DataModel;
using System.Reflection;

namespace BUS
{
    public class KhoaHocBUS : IKhoaHocBUS
    {
        private IKhoaHocDAO _res;
        public KhoaHocBUS(IKhoaHocDAO res)
        {
            _res = res;
        }
        public bool Create(KhoaHocModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(KhoaHocModel model)
        {
            throw new NotImplementedException();
        }

        public KhoaHocModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<KhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten_khoa)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khoa);
        }

        public bool Update(KhoaHocModel model)
        {
            return _res.Update(model);
        }
    }
}