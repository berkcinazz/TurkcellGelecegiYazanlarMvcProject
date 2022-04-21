using Core.Entities.Abstract;

namespace Entities.Dtos.UserBasketProduct
{
    public class UserBasketProductsForUpdateDTO : IDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
