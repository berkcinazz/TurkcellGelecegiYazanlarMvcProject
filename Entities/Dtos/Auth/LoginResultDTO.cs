using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Auth
{
    public class LoginResultDTO : IDto
    {
        public string Token { get; set; }
        public DateTime TokenExpires { get; set; }
        public UserForListingDTO User { get; set; }
    }
}
