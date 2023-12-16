using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.BaiViet
{
    public class BaiVietModel
    {
        public int IdBaiViet { get; set; }
        public int IdNguoiDung { get; set; }
        public string TieuDeBaiViet { get; set; }
        public string HinhAnh { get; set; }
        public string TomTat { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
