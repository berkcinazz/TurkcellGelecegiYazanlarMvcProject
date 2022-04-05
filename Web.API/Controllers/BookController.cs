using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAllBooks();
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
