using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ChuongModel
    {
        public int IdKhoaHoc { get; set; }
        public int IdChuong { get; set; }
        public string TenChuong { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<BaiHocModel> baiHocModels { get; set; }

    }
}
