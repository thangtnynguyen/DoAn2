using Microsoft.AspNetCore.Authorization;

namespace DoAn2.QLKhoaHoc.Api.Admin.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission): base(policy: permission)
        {
        }
    }
}
