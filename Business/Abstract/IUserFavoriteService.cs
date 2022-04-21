using Core.Utilities.Results;
using Entities.Dtos.UserFavorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserFavoriteService
    {
        IDataResult<List<UserFavoriteForListingDTO>> GetUserFavorite();
        IResult AddFavorite(UserFavoriteForAddDTO userFavoriteDTO);
        IResult DeleteFavorite(int id);
    }
}
