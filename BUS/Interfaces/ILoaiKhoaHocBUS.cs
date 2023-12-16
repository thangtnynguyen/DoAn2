using DataModel.LoaiKhoaHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface ILoaiKhoaHocBUS
    {
        public List<LoaiKhoaHocModel> SearchAll();

    }
}
