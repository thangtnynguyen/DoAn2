using DataModel.TacGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface ITacGiaBUS
    {
        public List<TacGiaModel> SearchAll();
    }
}
