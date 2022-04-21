using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Author;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAddressDal _authorDal;
        public AuthorManager(IAddressDal authorDal)
        {
            _authorDal = authorDal;
        }
        public IResult AddAuthor(AuthorForAddDto author)
        {
            var addToAuthor = new Author()
            {
                Name = author.Name,
                Surname = author.Surname
            };
            _authorDal.Add(addToAuthor);
            return new SuccessResult("Author Added");
        }
        public IResult DeleteAuthor(int authorId)
        {
            var result = _authorDal.Get(i => i.Id == authorId);
            if (result == null) return new ErrorResult("Author Not Found");
            _authorDal.Delete(result);
            return new SuccessResult("Author Has Been Deleted");
        }
        public IDataResult<List<Author>> GetAllAuthors()
        {
            var result = _authorDal.GetAll();
            return new SuccessDataResult<List<Author>>(result);
        }
        public IDataResult<Author> GetAuthorById(int authorId)
        {
            var result = _authorDal.Get(i => i.Id == authorId);
            if (result == null) return new ErrorDataResult<Author>("Author Not Found");
            return new SuccessDataResult<Author>(result);
        }
        public IResult UpdateAuthor(Author author)
        {
            var result = _authorDal.Get(i => i.Id == author.Id);
            if (result == null) return new ErrorResult("Author Not Found");
            result.Name = author.Name;
            result.Surname = author.Surname;
            _authorDal.Update(result);
            return new SuccessResult("Author Updated");
        }
    }
}
