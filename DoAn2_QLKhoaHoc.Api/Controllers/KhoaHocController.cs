using DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BUS;
using DataModel;
using BUS.Interfaces;

namespace DoAn2.QLKhoaHoc.Api.Admin.Controllers
{
    public class KhoaHocController : ControllerBase
    {
        private IKhoaHocBUS _khoahocbus;
        private string _path;
        private IWebHostEnvironment _env;
        public KhoaHocController(IKhoaHocBUS khoahocbus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _khoahocbus = khoahocbus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("create-khoahoc")]
        [HttpPost]
        public KhoaHocModel CreateItem([FromBody] KhoaHocModel model )
        {
            _khoahocbus.Create(model);
            return model;
        }
    }
}
