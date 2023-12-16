using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.BaiViet.TuongTac
{
    public class TuongTacBaiVietModel
    {
        public int IdBaiViet { get; set; }
        public int SoLike { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
