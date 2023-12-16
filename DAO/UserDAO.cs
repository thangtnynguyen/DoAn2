using DAO.Helper;
using DAO.Helper.Interfaces;
using DAO.Interfaces;
using DataModel.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO : IUserDAO
    {

        private ITruyVanDuLieu _truyvan;
        public UserDAO(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }

        public UserRequest DangNhap(UserRequest userRequest)
        {
            //UserModel model = new UserModel();
            //return model;

            string msgError = "";
            try
            {
                //string password = userRequest.PasswordHash;
                //string passwoedHash = password.HashPassword();
                //string query = "SELECT *  FROM Users WHERE Username = '"+ userRequest.UserName+"' AND PasswordHash = '"+ passwoedHash+"'";
                //var dt=_truyvan.ExecuteQueryToDataTable(query, out msgError);
                //if (!string.IsNullOrEmpty(msgError))
                //    throw new Exception(msgError);
                //return dt.ConvertTo<UserRequest>().FirstOrDefault();

                string query = "SELECT *  FROM Users WHERE Username = '" + userRequest.UserName + "'";
                var dt = _truyvan.ExecuteQueryToDataTable(query, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count!=0 && dt!=null)
                {
                     var user= dt.ConvertTo<UserRequest>().FirstOrDefault();
                    string passwoedHash = user.PasswordHash.ToString();
                    string password = userRequest.PasswordHash;
                    bool kq = password.VerifyPassword(passwoedHash);
                    if (kq)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
                
                                   

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

        public List<string> GetPermissionsByUserId(UserRequest userRequest)
        {
            // Thực hiện truy vấn để lấy thông tin về các permission của người dùng
            string permissionQuery = @"
            SELECT Permissions.Name
            FROM UserRoles
            INNER JOIN RolePermissions ON UserRoles.RoleId = RolePermissions.RoleId
            INNER JOIN Permissions ON RolePermissions.PermissionId = Permissions.Id
            WHERE UserRoles.UserId = '" + userRequest.Id + "'";

            var permissionsDt = _truyvan.ExecuteQueryToDataTable(permissionQuery, out string permissionError);
            if (!string.IsNullOrEmpty(permissionError))
            {
                throw new Exception(permissionError);
            }

            return permissionsDt.Rows.Cast<DataRow>().Select(row => row["Name"].ToString()).ToList();
        }

        public bool DangKi(UserRequest userRequest)
        {
            try
            {

                string password =userRequest.PasswordHash;
                string passwoedHash=password.HashPassword();
                string ere = "";
                object[] parameters = new object[] { "@Name", userRequest.Name, "@UserName", userRequest.UserName, "@Email", userRequest.Email, "@PasswordHash", passwoedHash };
                var dt = _truyvan.ExecuteScalarSProcedureWithTransaction(out ere, "sp_DangKi",parameters );
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public string GetRoleByUserId(UserRequest userRequest)
        {
            try
            {
                string roleQuery = @"
                SELECT Roles.Name
                FROM Roles
                INNER JOIN UserRoles ON UserRoles.RoleId = Roles.Id
                INNER JOIN Users ON UserRoles.UserId = Users.Id
                WHERE UserRoles.UserId = '" + userRequest.Id + "'";
                var roleDt = _truyvan.ExecuteQueryToDataTable(roleQuery, out string roleError);
                if (!string.IsNullOrEmpty(roleError))
                {
                    throw new Exception(roleError);
                }
                if (roleDt != null && roleDt.Rows.Count > 0)
                {
                    return roleDt.Rows.Cast<DataRow>().Select(row => row["Name"]).FirstOrDefault().ToString();

                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
