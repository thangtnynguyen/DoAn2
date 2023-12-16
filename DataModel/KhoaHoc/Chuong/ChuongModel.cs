using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.KhoaHoc.BaiHoc;

namespace DataModel.KhoaHoc.Chuong
{
    public class ChuongModel
    {
        public int IdKhoaHoc { get; set; }
        public int IdChuong { get; set; }
        public string TenChuong { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<BaiHocModel> baiHocModels { get; set; }
        //public int status { get; set; }


    }
}
