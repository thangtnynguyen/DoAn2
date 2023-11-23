using BUS.Interfaces;
using DAO.Interfaces;
using DataModel;

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