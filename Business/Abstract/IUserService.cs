using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Register(UserForRegisterDTO registerCredentials, byte[] passwordHash, byte[] passwordSalt);
        IDataResult<User> GetByGsm(string gsm);
        IDataResult<User> GetByMail(string mail);
        IDataResult<List<OperationClaim>> GetClaims(int userId);
    }
}
