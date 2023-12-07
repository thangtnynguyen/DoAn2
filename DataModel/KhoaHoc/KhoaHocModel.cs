using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.KhoaHoc
{
    public class KhoaHocModel
    {

        //public int Id { get; set; }
        //public string Ten { get; set; }
        //public int LoaiId { get; set; }
        //public string HinhAnh { get; set; }
        //public int TacGiaId { get; set; }
        //public Double Gia { get; set; }
        //public string VideoGioiThieu { get; set; }
        //public DateTime CreateAt { get; set; }
        //public DateTime UpdateAt { get; set; }


        public int Id { get; set; }

        public string Ten { get; set; }

        public string HinhAnh { get; set; }

        public string MoTa { get; set; }

        public string VideoGioiThieu { get; set; }

        public int TacGiaId { get; set; }

        public int LoaiId { get; set; }

        public float Gia { get; set; }

        public string TrangThai { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime? DeleteAt { get; set; }

        public List<ChuongModel> chuongModels { get; set; }



    }
}

