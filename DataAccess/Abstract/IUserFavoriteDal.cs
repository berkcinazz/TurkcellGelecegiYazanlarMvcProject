using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.UserFavorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserFavoriteDal : IRepositoryBase<UserFavorite>
    {
        List<UserFavoriteForListingDTO> GetFavorites(int userId);
    }
}
