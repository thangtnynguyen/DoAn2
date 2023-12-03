using DoAn2.QLKhoaHoc.Api.Admin.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace DoAn2.QLKhoaHoc.Api.Admin.Middlewares
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                context.Response.ContentType = "application/json";
                //context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.StatusCode = ex.Status;

                var errorResponse = new { status = ex.Status,message = ex.Message,Data = ex.Data };
                var jsonErrorResponse = JsonConvert.SerializeObject(errorResponse);

                await context.Response.WriteAsync(jsonErrorResponse);
            }
        }
    }
}
