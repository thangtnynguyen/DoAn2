
using DoAn2.QLKhoaHoc.Api.Admin.Constants;

namespace DoAn2.QLKhoaHoc.Api.Admin.Exceptions
{
    public class ApiException : Exception
    {
        public int Status { get; }
        public object Data { get; }

        public ApiException(string message, int status = HttpStatusCode.BadRequest, object data = null) : base(message)
        {
            Status = status;
            Data = data;
        }
    }
}