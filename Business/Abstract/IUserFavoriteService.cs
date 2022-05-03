using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<UserFavorite> GetUserFavoriteByProductId(int productId);
        IResult DeleteFavorite(int id);
        IResult UpdateFavorite(int productId);
    }
}
