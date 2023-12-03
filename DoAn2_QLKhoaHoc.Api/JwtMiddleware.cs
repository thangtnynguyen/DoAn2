using DoAn2.QLKhoaHoc.Api.Admin.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BUS;
using DataModel;
using BUS.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DoAn2.QLKhoaHoc.Api.Admin
{
    public class JwtMiddleware
    {

        private readonly IConfiguration _config;
        private IKhoaHocBUS _khoahocbus;
        public JwtMiddleware(  IConfiguration config, IKhoaHocBUS khoahocbus)
        {
            _config = config;
            _khoahocbus = khoahocbus;
        }

        //public async Task<string> CreateToken(UserModel user)
        //{
        //    var key = _config["Jwt:Key"];

        //    var permissions = await _userService.GetPermissionAsync(user);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimType.UserName, user.UserName),
        //        new Claim(ClaimType.Email, user.Email),
        //    };

        //    foreach (var permission in permissions)
        //    {
        //        claims.Add(new Claim(ClaimType.Permission, permission));
        //    }

        //    var subject = new ClaimsIdentity(claims);
        //    var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature);
        //    var expires = DateTime.UtcNow.AddDays(30);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = subject,
        //        Expires = expires,
        //        SigningCredentials = creds
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //    var token = tokenHandler.WriteToken(securityToken);

        //    return token;
        //}
    }
}
