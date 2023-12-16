using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.KhoaHoc.BaiHoc
{
    public class BaiHocModel
    {
        public int IdChuong { get; set; }
        public int IdBaiHoc { get; set; }
        public string TenBaiHoc { get; set; }
        public string Link { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
