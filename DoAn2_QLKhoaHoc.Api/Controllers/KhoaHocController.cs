﻿using DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BUS;
using BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DoAn2.QLKhoaHoc.Api.Admin.Attributes;
using DataModel.KhoaHoc;
using DataModel.Common;
using DoAn2.QLKhoaHoc.Api.Admin.Services;
using DoAn2.QLKhoaHoc.Api.Admin.Constants;

namespace DoAn2.QLKhoaHoc.Api.Admin.Controllers
{
    [Route("[controller]")]
    [HasPermission(Constants.Permission.ManageKhoaHoc)]
    public class KhoaHocController : ControllerBase
    {
        private IKhoaHocBUS _khoahocbus;
        private string _path;
        private IWebHostEnvironment _env;
        private readonly FileService _fileService;

        public KhoaHocController(IKhoaHocBUS khoahocbus, IConfiguration configuration, IWebHostEnvironment env,FileService fileService)
        {
            _khoahocbus = khoahocbus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
            _fileService = fileService;
        }
        [Route("create-khoahoc")]
        [HttpPost]
        //[AllowAnonymous]
        //[HasPermission(Constants.Permission.ManageKhoaHocCreate)]
        public async Task<ApiResult<KhoaHocModel>> CreateItem([FromForm] KhoaHocModel model )
        {
            if (model.HinhAnhFile?.Length > 0)
            {
                 model.HinhAnh = await _fileService.UploadFileAsync(model.HinhAnhFile, PathFolder.KhoaHoc);
            }
            if (_khoahocbus.Create(model)!=null)
            {
                return new ApiResult<KhoaHocModel>()
                {
                    Message = "Thêm khóa học thành công nhé",
                    Status = true,
                    Data = model
                };
            }
            else
            {
                return new ApiResult<KhoaHocModel>()
                {
                    Message = "Lỗi rồi",
                    Status = false,
                    Data = null
                };
            }           
        }
        [Route("get-khoahoc-by-id")]
        [HttpGet]
        //[HasPermission(Constants.Permission.ManageKhoaHocView)]
        //[AllowAnonymous]
        public KhoaHocModel GetDatabyID( [FromQuery] string id)
        {
            return _khoahocbus.GetDatabyID(id);
        }
        [Route("update-khoahoc")]
        [HttpPost]
        [HasPermission(Constants.Permission.ManageKhoaHocEdit)]
        public KhoaHocModel UpdateItem([FromForm] KhoaHocModel model)
        {
            _khoahocbus.Update(model);
            return model;
        }
        [Route("search-khoahoc")]
        [HttpPost]
        [AllowAnonymous]
        public ApiResult<PagingResult<KhoaHocModel>> Search([FromBody] GetKhoaHocRequest getKhoaHocRequest)
        {
            try
            {
                var data = _khoahocbus.Search(getKhoaHocRequest);
                return new ApiResult<PagingResult<KhoaHocModel>>()
                {
                    Status = true,
                    Message = "Danh sách khóa học đã được lấy thành công!",
                    Data = data
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("search-all")]
        [HttpGet]
        [AllowAnonymous]
        public ApiResult<List<KhoaHocModel>> SearchAll()
        {
            return new ApiResult<List<KhoaHocModel>>
            {
                Message = "Thành công",
                Status = true,
                Data = _khoahocbus.SearchAll()
            };
        }
        [Route("delete")]
        [HttpPost]
        [AllowAnonymous]
        public ApiResult<KhoaHocDelete> Delete([FromBody] KhoaHocDelete khoaHocDelete)
        {
            if (_khoahocbus.Delete(khoaHocDelete))
            {
                return new ApiResult<KhoaHocDelete>
                {
                    Message = "Xóa thành công rồi nhé",
                    Status = true,
                    Data = khoaHocDelete
                };
            }
            else
            {
                return new ApiResult<KhoaHocDelete>
                {
                    Message = "Lỗi, không có khóa học có id như vậy",
                    Status = false,
                    Data = khoaHocDelete
                };
            }
            
        }
        [Route("delete-multiple")]
        [HttpPost]
        [AllowAnonymous]
        public ApiResult<List<KhoaHocDelete>> DeleteMultiple([FromBody] List<KhoaHocDelete> khoaHocDeletes)
        {
            if (_khoahocbus.DeleteMultiple(khoaHocDeletes))
            {
                return new ApiResult<List<KhoaHocDelete>>
                {
                    Message = "Xóa thành công rồi nhé",
                    Status = true,
                    Data = khoaHocDeletes
                };
            }
            else
            {
                return new ApiResult<List<KhoaHocDelete>>
                {
                    Message = "Lỗi, không có khóa học có id như vậy",
                    Status = false,
                    Data = khoaHocDeletes
                };
            }

        }
    }
}
