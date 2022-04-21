using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserBasketProduct
{
    public class UserBasketProductsForAddDTO : IDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
