using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserBasketProduct
{
    public class UserBasketProductForCountListingDto:IDto
    {
        public int ProductId { get; set; }
        public int UserBasketId { get; set; }
        public float Count { get; set; }
    }
}
