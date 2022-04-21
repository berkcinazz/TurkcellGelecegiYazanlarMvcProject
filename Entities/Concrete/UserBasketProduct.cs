using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public partial class UserBasketProduct : IEntity
    {
        public UserBasketProduct()
        {
            Product = new Product();
            UserBasket = new UserBasket();
        }
        public int Id { get; set; }
        public int UserBasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public virtual Product Product { get; set; }
        public virtual UserBasket UserBasket { get; set; }

    }
}
