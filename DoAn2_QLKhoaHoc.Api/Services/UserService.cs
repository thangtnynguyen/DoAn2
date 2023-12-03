using BUS.Interfaces;
using DataModel;
using DoAn2.QLKhoaHoc.Api.Admin.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAn2.QLKhoaHoc.Api.Admin.Services
{
    public class UserService
    {
        private IUserBUS _userbus;
        private readonly IConfiguration _config;
        public UserService( IConfiguration config, IUserBUS userbus)
        {
            _config = config;
            _userbus= userbus;
            
        }

        public  string CreateToken(UserModel userModel)
        {
            var key = _config["Jwt:Key"];

            var permissions =  _userbus.GetPermissionsByUserId(userModel);

            var claims = new List<Claim>
            {
                new Claim(ClaimType.UserName, userModel.UserName),
                new Claim(ClaimType.Email, userModel.Email),
            };

            foreach (var permission in permissions)
            {
                claims.Add(new Claim(ClaimType.Permission, permission));
            }

            var subject = new ClaimsIdentity(claims);
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

            return token;
        }


    }
}
