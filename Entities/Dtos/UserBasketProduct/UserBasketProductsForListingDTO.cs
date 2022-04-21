using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserBasketProduct
{
    public class UserBasketProductsForListingDTO : IDto
    {
        public int Id { get; set; }
        public UserBasket UserBasket { get; set; }
        public Concrete.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
