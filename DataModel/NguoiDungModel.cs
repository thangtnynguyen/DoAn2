using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NguoiDungModel
    {
        public int Id { get; set; }
        public string TenKH { get; set; }
        public bool TenDangNhap { get; set; }
        public string AnhDaiDien { get; set; }
        public string Quyen { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; } 
    }
}
