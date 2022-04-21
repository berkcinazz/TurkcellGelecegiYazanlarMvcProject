using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAllCreditCards();
        IResult AddCreditCard(CreditCardForAddDTO creditCard);
        IResult UpdateCreditCardTitle(CreditCardForUpdateDTO creditCard);
        IResult DeleteCreditCard(int id);
    }
}
