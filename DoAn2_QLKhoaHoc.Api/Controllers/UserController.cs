using DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BUS;
using DataModel;
using BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using DoAn2.QLKhoaHoc.Api.Admin.Services;
using DoAn2.QLKhoaHoc.Api.Admin.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAn2.QLKhoaHoc.Api.Admin.Controllers
{
    public class UserController : ControllerBase
    {
        private IUserBUS _userbus;
        private string _path;
        private IWebHostEnvironment _env;
        //private readonly UserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserBUS userbus, IConfiguration configuration, IWebHostEnvironment env, IConfiguration config)
        {
            _userbus = userbus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
            _config = config;
        }

        [Route("login")]
        [HttpPost]
        public ApiResult<string> Login([FromBody] UserModel userModel)
        {

            if (_userbus.DangNhap(userModel)!=null)
            {
                //var token =_userService.CreateToken(_userbus.DangNhap(userModel));

                var permissions = _userbus.GetPermissionsByUserId(_userbus.DangNhap(userModel));

                var claims = new List<Claim>
                {
                    new Claim(ClaimType.UserName, _userbus.DangNhap(userModel).UserName),
                    new Claim(ClaimType.Email, _userbus.DangNhap(userModel).Email),
                };

                foreach (var permission in permissions)
                {
                    claims.Add(new Claim(ClaimType.Permission, permission));
                }

                var subject = new ClaimsIdentity(claims);
                var key = _config["Jwt:Key"];
                var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature);
                var expires = DateTime.UtcNow.AddDays(30);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);



                return new ApiResult<string>()
                {
                    Status = true,
                    Message = "Đăng nhập thành công!",
                    Data = token.ToString()
                };
            }
            else
            {
                return new ApiResult<string>()
                {
                    Status = false,
                    Message = "Tạo mã thông báo thất bại!",
                };
            }    
            
        }
    }
}
