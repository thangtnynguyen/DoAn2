using DataModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IUserBUS
    {
        UserRequest DangNhap(UserRequest userRequest);
        List<string> GetPermissionsByUserId(UserRequest userRequest);
        public bool DangKi(UserRequest userRequest);
        public string GetRoleByUserId(UserRequest userRequest);

    }
}
