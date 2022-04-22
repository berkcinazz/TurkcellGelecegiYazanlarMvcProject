using Business.Abstract;
using Entities.Dtos.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("get-all-brands")]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetAllBrands();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-brand")]
        public IActionResult AddBrand(BrandForAddDTO brand)
        {
            var result = _brandService.AddBrand(brand);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-brand")]
        public IActionResult DeleteBrand(int brandId)
        {
            var result = _brandService.DeleteBrand(brandId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-brand")]
        public IActionResult UpdateBrand(BrandForUpdateDTO brand)
        {
            var result = _brandService.UpdateBrand(brand);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-brand-by-id")]
        public IActionResult GetBrandById(int brandId)
        {
            var result = _brandService.GetBrandById(brandId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
