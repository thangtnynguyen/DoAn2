﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public partial interface ILoaiKhoaHocDAO
    {
        public List<LoaiKhoaHocModel> SearchAll();

    }
}
