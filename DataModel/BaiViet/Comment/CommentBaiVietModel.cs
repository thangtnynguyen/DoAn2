using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.BaiViet.Comment
{
    public class CommentBaiVietModel
    {
        public int IdComment { get; set; }
        public int IdBaiViet { get; set; }
        public int IdNguoiViet { get; set; }
        public string NoiDungCmt { get; set; }
        public string HinhAnhCmt { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
