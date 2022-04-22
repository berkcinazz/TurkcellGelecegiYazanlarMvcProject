using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private IUserBasketService _userBasketService;
        public UserManager(IUserDal userDal, IUserBasketService userBasketService)
        {
            _userDal = userDal;
            _userBasketService = userBasketService;
        }
        public IDataResult<User> GetByGsm(string gsm)
        {
            var result = _userDal.Get(u => u.Gsm == gsm);
            if (result == null)
                return new ErrorDataResult<User>();
            return new SuccessDataResult<User>(result);
        }
        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result == null)
                return new ErrorDataResult<User>();
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var result = _userDal.Get(u => u.Mail == mail);
            if (result == null)
                return new ErrorDataResult<User>(Messages.NoUserFoundWithThisMail);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(int userId)
        {
            if (!GetById(userId).Success)
                return new ErrorDataResult<List<OperationClaim>>();
            var claims = _userDal.GetOperationClaims(userId);
            return new SuccessDataResult<List<OperationClaim>>(claims);
        }
        public IDataResult<User> Register(UserForRegisterDTO registerCredentials, byte[] passwordHash, byte[] passwordSalt)
        {
            User userToRegister = new User()
            {
                Approved = false,
                DateOfBirth = registerCredentials.DateOfBirth,
                Gender = registerCredentials.Gender,
                Gsm = registerCredentials.Gsm,
                Mail = registerCredentials.Mail,
                Name = registerCredentials.Name,
                Surname = registerCredentials.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Address = registerCredentials.Address 
            };
            _userDal.Add(userToRegister);
            _userBasketService.AddUserBasket(userToRegister.Id);
            return new SuccessDataResult<User>(userToRegister, String.Format(Messages.RegisterSuccessfullWelcome, $"{userToRegister.Name} {userToRegister.Surname}"));
        }
    }
}
