using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IUserBUS
    {
        UserModel DangNhap(UserModel userModel);
        List<string> GetPermissionsByUserId(UserModel userModel);


    }
}
