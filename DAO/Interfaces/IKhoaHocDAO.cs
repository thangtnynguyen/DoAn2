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
        public bool DeleteMultiple(List<KhoaHocDelete> khoaHocDeletes);

        public PagingResult<KhoaHocModel> Search(GetKhoaHocRequest getKhoaHocRequest);

        public List<KhoaHocModel> SearchAll();



    }
}
