using Core.Utilities.Helpers;
using Entities.Dtos.Product;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class ProductViewModel
    {
        public List<ProductForListingDTO> ProductList { get; set; }
        public Pager Pager { get; internal set; }
        public int CurrentPage { get; internal set; }

        public ProductViewModel()
        {
            this.ProductList = new List<ProductForListingDTO>();
        }
    }
}
