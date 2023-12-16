using BUS.Interfaces;
using DAO.Interfaces;
using DataModel.LoaiKhoaHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiKhoaHocBUS:ILoaiKhoaHocBUS
    {
        private ILoaiKhoaHocDAO _dao;
        public LoaiKhoaHocBUS(ILoaiKhoaHocDAO dao)
        {
            _dao = dao;
        }
        public List<LoaiKhoaHocModel> SearchAll()
        {
            return _dao.SearchAll();
        }
    }
}
