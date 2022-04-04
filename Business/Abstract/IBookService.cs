using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Book;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBookService
    {
        IResult AddBook(BookForAddDto book);
        IResult DeleteBook(int bookId);
        IResult UpdateBook(Book book);
        IDataResult<List<Book>> GetAllBooks();
        IDataResult<Book> GetBookById(int bookId);
    }
}
