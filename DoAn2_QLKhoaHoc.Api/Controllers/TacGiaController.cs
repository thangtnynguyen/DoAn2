using BUS;
using BUS.Interfaces;
using DataModel;
using DataModel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn2.QLKhoaHoc.Api.Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TacGiaController : ControllerBase
    {
        private ITacGiaBUS _tacgiabus;
        private string _path;
        private IWebHostEnvironment _env;
        public TacGiaController(ITacGiaBUS tacgiabus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _tacgiabus = tacgiabus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("search-all")]
        [HttpGet]
        public ApiResult<List<TacGiaModel>> SearchAll()
        {
            return new ApiResult<List<TacGiaModel>>
            {
                Message = "Thành công",
                Status = true,
                Data = _tacgiabus.SearchAll()
            };
        }



    }
}
