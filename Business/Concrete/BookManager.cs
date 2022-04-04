using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Book;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public IResult AddBook(BookForAddDto book)
        {
            var addToBook = new Book()
            {
                Name = book.Name,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                Price = book.Price,
                PublishDate = book.PublishDate,
                PublisherId = book.PublisherId,
            };
            _bookDal.Add(addToBook);
            return new SuccessResult("Book Added");
        }
        public IResult DeleteBook(int bookId)
        {
            var result = _bookDal.Get(i => i.Id == bookId);
            if (result == null) return new ErrorResult("Book Not Found");
            _bookDal.Delete(result);
            return new SuccessResult("Book Has Been Deleted");
        }
        public IDataResult<List<Book>> GetAllBooks()
        {
            var result = _bookDal.GetAll();
            return new SuccessDataResult<List<Book>>(result);
        }
        public IDataResult<Book> GetBookById(int bookId)
        {
            var result = _bookDal.Get(i => i.Id == bookId);
            if (result == null) return new ErrorDataResult<Book>("Book Not Found");
            return new SuccessDataResult<Book>(result);
        }
        public IResult UpdateBook(Book book)
        {
            var result = _bookDal.Get(i => i.Id == book.Id);
            if (result == null) return new ErrorResult("Book Not Found");
            result.Name = book.Name;
            result.CategoryId = book.CategoryId;
            result.Price = book.Price;
            result.PublisherId = book.PublisherId;
            result.AuthorId = book.AuthorId;
            result.PublishDate = book.PublishDate;
            _bookDal.Update(result);
            return new SuccessResult("Book Updated");
        }
    }
}
