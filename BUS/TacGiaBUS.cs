using BUS.Interfaces;
using DAO.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TacGiaBUS : ITacGiaBUS
    {
        private ITacGiaDAO _dao;
        public TacGiaBUS(ITacGiaDAO dao)
        {
            _dao = dao;
        }
        public List<TacGiaModel> SearchAll()
        {
            return _dao.SearchAll();
        }
    }
}
