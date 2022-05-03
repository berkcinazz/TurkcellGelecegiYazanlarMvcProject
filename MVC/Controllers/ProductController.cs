using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Entities.Dtos.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductService _productService;
        IUserFavoriteService _userFavoriteService;

        public ProductController(IProductService productService, IUserFavoriteService userFavoriteService)
        {
            _productService = productService;
            _userFavoriteService = userFavoriteService;
        }

        // GET: ProductsController
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts().Data;
            ProductViewModel productViewModel = new ProductViewModel();
            for (int i = 0; i < products.Count; i++)
            {
                productViewModel.ProductList.Add(products[i]);
            }
            productViewModel.Pager = new Pager(productViewModel.ProductList.Count, 5, 2);
            return View(productViewModel);
        }
        
        // GET: ProductsController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        // GET: ProductsController/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id).Data;
            ProductForUpdateDto productToUpdate = new ProductForUpdateDto()
            {
                Id= product.Id,
                Name = product.Name,
                ProductCode = product.ProductCode,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                QuantityPerUnit = product.QuantityPerUnit,
                OnSale = product.OnSale,
                Active = product.Active,
                Description = product.Description,
                BrandId = product.BrandId,
            };
            return View(productToUpdate);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult AddProduct(ProductForAddDto product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _productService.AddNewProduct(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateProduct(ProductForUpdateDto product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        public IActionResult Priority(int page = 1)
        {
            var productList = _productService.GetAllProducts().Data;
            Pager pager = new Pager(productList.Count(), page, 5);
            productList = productList.Skip((page - 1) * 5).Take(5).ToList();
            ProductViewModel model = new ProductViewModel()
            {
                Pager = pager,
                ProductList = productList.ToList(),
                CurrentPage = page
            };
            return View(model);
        }
        [HttpPost]
        public Task ChangeFavoriteOfProductForUser(int productId)
        {
            var result = _userFavoriteService.UpdateFavorite(productId);
            return Task.FromResult(result.Message);
            
        }
    }
}
