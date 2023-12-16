using DataModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public partial interface IUserDAO
    {

        UserRequest DangNhap(UserRequest userRequest);
        List<string> GetPermissionsByUserId(UserRequest userRequest);
        bool DangKi(UserRequest userRequest);
        public string GetRoleByUserId(UserRequest userRequest);

    }
}
