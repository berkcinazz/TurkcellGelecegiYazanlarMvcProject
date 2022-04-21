using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos.Auth;
using System;
using System.Threading;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IResult Register(UserForRegisterDTO registerCredentials)
        {
            var businessRules = BusinessRules.Run(UserShouldNotExistWithMail(registerCredentials.Mail), UserShouldNotExistWithGsm(registerCredentials.Gsm));
            if (businessRules != null) return businessRules;
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerCredentials.Password, out passwordHash, out passwordSalt);
            var result = _userService.Register(registerCredentials, passwordHash, passwordSalt);
            return result;
        }
        public IDataResult<LoginResultDTO> Login(UserForLoginDTO loginCredentials)
        {
            var user = _userService.GetByMail(loginCredentials.Mail);
            if (!user.Success || user.Data == null) return new ErrorDataResult<LoginResultDTO>(user.Message);

            var passwordCompare = HashingHelper.VerifyPasswordHash(loginCredentials.Password, user.Data.PasswordHash, user.Data.PasswordSalt);
            if (!passwordCompare) return new ErrorDataResult<LoginResultDTO>(Messages.PasswordInvalid);

            var token = CreateAccessToken(user.Data);
            LoginResultDTO result = new LoginResultDTO() { Token = token.Token, TokenExpires = token.Expiration, User = new UserForListingDTO() { Email = user.Data.Mail, Name = user.Data.Name, Surname = user.Data.Surname } };
            return new SuccessDataResult<LoginResultDTO>(result);
        }
        private AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user.Id);
            return _tokenHelper.CreateToken(user, claims.Data);
        }
        #region Business Rules
        private IResult UserShouldNotExistWithMail(string mail)
        {
            var result = _userService.GetByMail(mail);
            if (result.Data != null) return new ErrorResult(Messages.UserExistsWithSameMail);
            return new SuccessResult();
        }
        private IResult UserShouldNotExistWithGsm(string gsm)
        {
            var result = _userService.GetByGsm(gsm);
            if (result.Data != null) return new ErrorResult(Messages.UserExistsWithSameGsm);
            return new SuccessResult();
        }
        #endregion
    }
}
