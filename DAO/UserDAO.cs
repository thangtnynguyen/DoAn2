using DAO.Helper;
using DAO.Helper.Interfaces;
using DAO.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO : IUserDAO
    {

        private ITruyVanDuLieu _dbHelper;
        public UserDAO(ITruyVanDuLieu dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public UserModel DangNhap(UserModel userModel)
        {
            //UserModel model = new UserModel();
            //return model;

            string msgError = "";
            try
            {
                string query = "SELECT *  FROM Users WHERE Username = '"+userModel.UserName+"' AND PasswordHash = '"+userModel.PasswordHash+"'";
                var dt=_dbHelper.ExecuteQueryToDataTable(query, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

        public List<string> GetPermissionsByUserId(UserModel userModel)
        {
            // Thực hiện truy vấn để lấy thông tin về các permission của người dùng
            string permissionQuery = @"
            SELECT Permissions.Name
            FROM UserRoles
            INNER JOIN RolePermissions ON UserRoles.RoleId = RolePermissions.RoleId
            INNER JOIN Permissions ON RolePermissions.PermissionId = Permissions.Id
            WHERE UserRoles.UserId = '" + userModel.Id + "'";

            var permissionsDt = _dbHelper.ExecuteQueryToDataTable(permissionQuery, out string permissionError);
            if (!string.IsNullOrEmpty(permissionError))
            {
                throw new Exception(permissionError);
            }

            return permissionsDt.Rows.Cast<DataRow>().Select(row => row["Name"].ToString()).ToList();
        }

    }
}
