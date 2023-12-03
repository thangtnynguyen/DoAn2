using DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BUS;
using DataModel;
using BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DoAn2.QLKhoaHoc.Api.Admin.Attributes;

namespace DoAn2.QLKhoaHoc.Api.Admin.Controllers
{
    [HasPermission(Constants.Permission.ManageKhoaHoc)]
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
        [Route("get-khoahoc-by-id")]
        [HttpGet]
        [HasPermission(Constants.Permission.ManageKhoaHocView)]
        public KhoaHocModel GetDatabyID( [FromQuery] string id)
        {
            return _khoahocbus.GetDatabyID(id);
        }
        [Route("update-khoahoc")]
        [HttpPost]
        public KhoaHocModel UpdateItem([FromBody] KhoaHocModel model)
        {
            _khoahocbus.Update(model);
            return model;
        }
        [Route("search-khoahoc")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_khoa = "";
                if (formData.Keys.Contains("ten_khoa") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khoa"]))) { ten_khoa = Convert.ToString(formData["ten_khoa"]); }
                long total = 0;
                var data = _khoahocbus.Search(page, pageSize, out total, ten_khoa);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
