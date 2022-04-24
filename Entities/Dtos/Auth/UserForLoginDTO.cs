using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Auth
{
    public class UserForLoginDTO : IDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
