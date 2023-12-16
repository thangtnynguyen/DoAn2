using BUS;
using BUS.Interfaces;
using DataModel.Common;
using DataModel.LoaiKhoaHoc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn2.QLKhoaHoc.Api.Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {

        private ILoaiKhoaHocBUS _loaikhoahocbus;
        private string _path;
        private IWebHostEnvironment _env;
        public LoaiKhoaHocController(ILoaiKhoaHocBUS loaikhoahocbus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _loaikhoahocbus = loaikhoahocbus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }

        [Route("search-all")]
        [HttpGet]
        public ApiResult<List<LoaiKhoaHocModel>> SearchAll()
        {
            return new ApiResult<List<LoaiKhoaHocModel>>
            {
                Message = "Thành công",
                Status = true,
                Data = _loaikhoahocbus.SearchAll()
            };
        }
    }
}
