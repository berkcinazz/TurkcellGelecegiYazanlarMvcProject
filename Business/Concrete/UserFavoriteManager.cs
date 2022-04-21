using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserFavorite;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserFavoriteManager : IUserFavoriteService
    {
        IUserFavoriteDal _userFavoriteDal;
        IHttpContextAccessor _httpContextAccessor;

        public UserFavoriteManager(IUserFavoriteDal userFavoriteDal)
        {
            _userFavoriteDal = userFavoriteDal;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public IResult AddFavorite(UserFavoriteForAddDTO userFavoriteDTO)

        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var businessRulesResult = BusinessRules.Run(FavoriteShouldNotExists(userFavoriteDTO.ProductId, userId));
            if (businessRulesResult != null) return businessRulesResult;
            UserFavorite userFavorite = new UserFavorite()
            {
                ProductId = userFavoriteDTO.ProductId,
                UserId = userId,
                AddedDate = DateTime.Now
            };
            _userFavoriteDal.Add(userFavorite);
            return new SuccessResult(Messages.FavoriteProductAdded);
        }

        public IResult DeleteFavorite(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _userFavoriteDal.Get(i => i.Id == id && i.UserId == userId);
            var businessRulesResult = BusinessRules.Run(FavoriteCanNotBeNull(id, userId));
            if (businessRulesResult != null) return businessRulesResult;

            _userFavoriteDal.Delete(result);
            return new SuccessResult(Messages.FavoriteProductDeleted);
        }

        public IDataResult<List<UserFavoriteForListingDTO>> GetUserFavorite()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _userFavoriteDal.GetFavorites(userId);
            if (result == null)
            {
                return new ErrorDataResult<List<UserFavoriteForListingDTO>>(Messages.UserFavoritesNotFound);
            }
            return new SuccessDataResult<List<UserFavoriteForListingDTO>>(result);
        }
        #region Business Rules
        private IResult FavoriteCanNotBeNull(int id, int userId)
        {
            var result = _userFavoriteDal.Get(i => i.Id == id && i.UserId == userId);
            if (result == null) return new ErrorResult(Messages.FavoriteProductNotFound);
            return new SuccessResult();
        }
        private IResult FavoriteShouldNotExists(int productId, int userId)
        {
            var result = _userFavoriteDal.Get(i => i.ProductId == productId && i.UserId == userId);
            if (result != null) return new ErrorResult(Messages.FavoriteAlreadyExists);
            return new SuccessResult();
        }
        #endregion

    }
}
