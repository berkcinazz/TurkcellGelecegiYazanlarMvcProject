using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.UserFavorite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfUserFavoriteDal : EFRepositoryBase<UserFavorite, EFCoreContext>, IUserFavoriteDal
    {
        public List<UserFavoriteForListingDTO> GetFavorites(int userId)
        {
            using (var context = new EFCoreContext())
            {
                var result = context.UserFavorites.Include(i=>i.UserId).Select(s=> new UserFavoriteForListingDTO
                {
                    AddedDate = s.AddedDate,
                    Product = s.Product,
                }).Where(w => w.UserId == userId).ToList();
                return result.ToList();
            }
        }
    }
}
