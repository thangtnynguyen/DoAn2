using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public partial interface IBaiVietDAO
    {
        BaiVietModel GetDatabyID(string id);
        bool Create(BaiVietModel model);
        bool Update(BaiVietModel model);
        bool Delete(BaiVietModel model);
        public List<BaiVietModel> Search(int pageIndex, int pageSize, out long total, string ten_loai);
    }
}
