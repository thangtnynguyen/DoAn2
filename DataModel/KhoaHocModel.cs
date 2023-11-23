using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class KhoaHocModel
    {

        public int Id { get; set; }
        public string Ten { get; set; }
        public int LoaiId { get; set; }
        public string HinhAnh { get; set; }
        public int TacGiaId { get; set; }
        public Double Gia { get; set; }
        public string VideoGioiThieu { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public List<ChuongModel> chuongModels { get; set; }

    }
}

