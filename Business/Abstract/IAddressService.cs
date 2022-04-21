using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<Address>> GetAddressesByUserId();
        IResult AddUserAddress(UserAddressForAddDTO address);
        IResult UpdateUserAddress(UserAddressForUpdateDTO address);
        IResult DeleteUserAddress(int id);
    }
}
