using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Book;
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
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAllBooks();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-book-by-id")]
        public IActionResult GetBookById(int bookId)
        {
            var result = _bookService.GetBookById(bookId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-book")]
        public IActionResult AddBook(BookForAddDto book)
        {
            var result = _bookService.AddBook(book);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-book")]
        public IActionResult UpdateBook(Book book)
        {
            var result = _bookService.UpdateBook(book);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-book")]
        public IActionResult DeleteBook(int bookId)
        {
            var result = _bookService.DeleteBook(bookId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
