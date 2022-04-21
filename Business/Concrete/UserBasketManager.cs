using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserBasketManager : IUserBasketService
    {
        IUserBasketDal _userBasketDal;

        public UserBasketManager(IUserBasketDal userBasketDal)
        {
            _userBasketDal = userBasketDal;
        }

        public IResult AddUserBasket(int userId)
        {
            UserBasket userBasketToAdd = new UserBasket()
            {
                UserId = userId
            };
            _userBasketDal.Add(userBasketToAdd);
            return new SuccessResult(Messages.UserBasketCreated);
        }

        public IDataResult<UserBasket> GetUserBasket(int userId)
        {
            var result = _userBasketDal.Get(i => i.UserId == userId);
            if (result == null) return new ErrorDataResult<UserBasket>(Messages.UserBasketNotFound);
            return new SuccessDataResult<UserBasket>(result);
        }
    }
}
