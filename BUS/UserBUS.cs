using BUS.Interfaces;
using DAO.Interfaces;
using DataModel.User;
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
        private IUserDAO _iuserDAO;
        public UserBUS(IUserDAO res)
        {
            _iuserDAO = res;
        }

        public UserRequest DangNhap(UserRequest userRequest)
        {
            return _iuserDAO.DangNhap(userRequest);
        }
        public List<string> GetPermissionsByUserId(UserRequest userRequest)
        {
            return _iuserDAO.GetPermissionsByUserId(userRequest);
        }
        public bool DangKi(UserRequest userRequest)
        {
            return _iuserDAO.DangKi(userRequest);
        }




    }
}
