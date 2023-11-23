using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class KhoaHocNguoiDungModel
    {
        public int IdKhoaHoc { get; set; }
        public int IdNguoiDung { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
