using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.HDBan
{
    public class HoaDonBanModel
    {
        public int IdHDB { get; set; }
        public int IdKhach { get; set; }
        public double ThanhTien { get; set; }
        public DateTime NgayBan { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
    public class CTHoaDonBanModel
    {
        public int IdHDB { get; set; }
        public int IdKhoaHoc { get; set; }
        public double Gia { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
