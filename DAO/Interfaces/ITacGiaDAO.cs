﻿using DataModel.TacGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public partial interface ITacGiaDAO
    {
        public List<TacGiaModel> SearchAll();
    }
}
