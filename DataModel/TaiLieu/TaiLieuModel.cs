using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.TaiLieu
{
    public class TaiLieuModel
    {
        public int IdKhoaHoc { get; set; }
        public int IdTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }
        public string Link { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
