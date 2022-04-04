using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Author;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IResult AddAuthor(AuthorForAddDto author);
        IResult DeleteAuthor(int authorId);
        IResult UpdateAuthor(Author author);
        IDataResult<List<Author>> GetAllAuthors();
        IDataResult<Author> GetAuthorById(int authorId);
    }
}
