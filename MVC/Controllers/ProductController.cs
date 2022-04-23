using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductsController
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products.Data);
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
    }
}
