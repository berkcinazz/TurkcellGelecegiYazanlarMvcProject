using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("get-all-authors")]
        public IActionResult GetAllauthors()
        {
            var result = _authorService.GetAllAuthors();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-author-by-id")]
        public IActionResult GetauthorById(int authorId)
        {
            var result = _authorService.GetAuthorById(authorId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-author")]
        public IActionResult Addauthor(AuthorForAddDto author)
        {
            var result = _authorService.AddAuthor(author);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-author")]
        public IActionResult Updateauthor(Author author)
        {
            var result = _authorService.UpdateAuthor(author);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-author")]
        public IActionResult Deleteauthor(int authorId)
        {
            var result = _authorService.DeleteAuthor(authorId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
