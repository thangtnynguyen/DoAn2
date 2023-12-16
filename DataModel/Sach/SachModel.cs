using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Sach
{
    public class SachModel
    {
        public int Id { get; set; }
        public string TenSach { get; set; }
        public bool MoTa { get; set; }
        public string HinhAnh { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
