using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Helpers;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.CreditCard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        IHttpContextAccessor _httpContextAccessor;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public IResult AddCreditCard(CreditCardForAddDTO creditCard)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _creditCardDal.Get(c => c.UserId == userId && c.Number == creditCard.Number);
            if (result != null) return new ErrorResult(Messages.CreditCardAlreadyExists);
            CreditCard creditCardToAdd = new CreditCard()
            {
                Title = creditCard.Title,
                OwnersName = creditCard.OwnersName,
                Number = StringHelper.RemoveWhitespace(creditCard.Number),
                ExpireDate = creditCard.ExpireDate,
                Cvv = creditCard.CVV,
                UserId = userId,
                CreditCardType = CreditCardTypeHelper.FindCreditCardType(creditCard.Number)
            };
            _creditCardDal.Add(creditCardToAdd);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult DeleteCreditCard(int id)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var creditCardForDelete = _creditCardDal.Get(c => c.Id == id && c.UserId == userId);
            if (creditCardForDelete == null) return new ErrorResult(Messages.CreditCardNotFound);
            creditCardForDelete.Id = id;
            _creditCardDal.Delete(creditCardForDelete);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAllCreditCards()
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _creditCardDal.GetAll(c => c.UserId == userId);
            if (result == null) return new ErrorDataResult<List<CreditCard>>(Messages.CreditCardDoesntExists);
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        public IResult UpdateCreditCardTitle(CreditCardForUpdateDTO creditCard)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            CreditCard creditCardToUpdate = _creditCardDal.Get(c => c.Id == creditCard.Id && c.UserId == userId);
            if (creditCardToUpdate == null) return new ErrorResult(Messages.CreditCardNotFound);
            creditCardToUpdate.Id = creditCard.Id;
            creditCardToUpdate.Title = creditCard.Title;
            _creditCardDal.Update(creditCardToUpdate);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
