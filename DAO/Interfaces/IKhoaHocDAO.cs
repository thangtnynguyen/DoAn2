using DataModel.Common;
using DataModel.KhoaHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public partial interface IKhoaHocDAO
    {
        KhoaHocModel GetDatabyID(string id);
        bool Create(KhoaHocModel model);
        bool Update(KhoaHocModel model);
        bool Delete(KhoaHocDelete khoaHocDelete);
        //public List<KhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten_khoa);
        public PagingResult<KhoaHocModel> Search(GetKhoaHocRequest getKhoaHocRequest);

        public List<KhoaHocModel> SearchAll();



    }
}
