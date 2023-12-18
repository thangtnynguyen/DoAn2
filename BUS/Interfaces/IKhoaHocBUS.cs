using DataModel.Common;
using DataModel.KhoaHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public interface  IKhoaHocBUS
    {
        KhoaHocModel GetDatabyID(string id);
        bool Create(KhoaHocModel model);
        bool Update(KhoaHocModel model);
        public bool DeleteMultiple(List<KhoaHocDelete> khoaHocDeletes);
        public PagingResult<KhoaHocModel> Search(GetKhoaHocRequest getKhoaHocRequest);
        public List<KhoaHocModel> SearchAll();
        bool Delete(KhoaHocDelete khoaHocDelete);

    }
}
