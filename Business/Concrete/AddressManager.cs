using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Dtos.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        IHttpContextAccessor _httpContextAccessor;
        public AddressManager(IAddressDal addressDal)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _addressDal = addressDal;
        }
        public IResult AddUserAddress(UserAddressForAddDTO address)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            Address addresToAdd = new Address()
            {
                Title = address.Title,
                City = address.City,
                District = address.District,
                Quarter = address.Quarter,
                AddressString = address.AddressString,
                Name = address.Name,
                Surname = address.Surname,
                Gsm = address.Gsm,
                UserId = userId
            };
            _addressDal.Add(addresToAdd);
            return new SuccessResult(Messages.UserAddressAdded);
        }

        public IResult DeleteUserAddress(int id)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            Address addresToDelete = _addressDal.Get(a => a.Id == id && a.UserId == userId);
            if (addresToDelete == null)
            {
                return new ErrorResult(Messages.UserAddressNotExists);
            }
            _addressDal.Delete(addresToDelete);
            return new SuccessResult(Messages.UserAddressDeleted);
        }

        public IDataResult<List<Address>> GetAddressesByUserId()
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _addressDal.GetAll(a => a.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<List<Address>>(Messages.UserAddressNotExists);
            }
            return new SuccessDataResult<List<Address>>(result);

        }
        public IResult UpdateUserAddress(UserAddressForUpdateDTO address)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            Address addresToUpdate = _addressDal.Get(a => a.Id == address.Id && a.UserId == userId);
            if (addresToUpdate == null)
            {
                return new ErrorResult(Messages.UserAddressNotExists);
            }
            addresToUpdate.Id = address.Id;
            addresToUpdate.Title = address.Title;
            addresToUpdate.City = address.City;
            addresToUpdate.District = address.District;
            addresToUpdate.Quarter = address.Quarter;
            addresToUpdate.AddressString = address.AddressString;
            addresToUpdate.Name = address.Name;
            addresToUpdate.Surname = address.Surname;
            addresToUpdate.Gsm = address.Gsm;
            addresToUpdate.UserId = userId;
            _addressDal.Update(addresToUpdate);
            return new SuccessResult(Messages.UserAddressUpdated);
        }
    }
}
