using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Entities.Dtos.UserFavorite
{
    public class UserFavoriteForListingDTO : IDto
    {
        public Concrete.Product Product { get; set; }
        public DateTime AddedDate { get; set; }
        public int UserId{ get; set; }
    }
}
