using DataModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Common
{
    public class TokenRole
    {

        public string? Token { get; set; }

        public string? Role { get; set; }

        public UserRequest UserRequest { get; set; }

    }
}
