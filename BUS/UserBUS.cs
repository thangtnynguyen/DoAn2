using BUS.Interfaces;
using DAO.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserBUS:IUserBUS
    {
        private IUserDAO _res;
        public UserBUS(IUserDAO res)
        {
            _res = res;
        }

        public UserModel DangNhap(UserModel userModel)
        {
            return _res.DangNhap(userModel);
        }
        public List<string> GetPermissionsByUserId(UserModel userModel)
        {
            return _res.GetPermissionsByUserId(userModel);
        }
        

    }
}
