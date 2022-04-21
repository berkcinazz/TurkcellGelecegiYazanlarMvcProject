using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserBasketProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserBasketProductManager : IUserBasketProductService
    {
        IUserBasketProductDal _userBasketProductDal;
        IHttpContextAccessor _httpContextAccessor;
        IUserBasketService _userBasketService;
        IProductService _productService;

        public UserBasketProductManager(IUserBasketProductDal userBasketProductDal, IUserBasketService userBasketService, IProductService productService)
        {
            _userBasketProductDal = userBasketProductDal;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _userBasketService = userBasketService;
            _productService = productService;
        }

        public IResult AddProductToBasket(UserBasketProductsForAddDTO userBasketProduct)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var userBasket = _userBasketService.GetUserBasket(userId);

            var productToAdd = GetIfProductExists(userBasketProduct.ProductId);
            if (!productToAdd.Success) return new ErrorResult(Messages.ProductNotFound);

            var businesRules = BusinessRules.Run(ProductHasStocks(productToAdd.Data, userBasketProduct.Quantity));
            if (businesRules != null) return businesRules;

            UserBasketProduct userBasketProductToAdd = _userBasketProductDal.Get(i => i.UserBasketId == userBasket.Data.Id && i.ProductId == userBasketProduct.ProductId);
            if (userBasketProductToAdd == null)
            {
                userBasketProductToAdd = new UserBasketProduct()
                {
                    Quantity = userBasketProduct.Quantity,
                    ProductId = userBasketProduct.ProductId,
                    UserBasketId = userBasket.Data.Id,
                };
                _userBasketProductDal.Add(userBasketProductToAdd);
            }
            else
            {
                var newQuantity = userBasketProductToAdd.Quantity + userBasketProduct.Quantity;
                if (!ProductHasStocks(productToAdd.Data, newQuantity).Success) return new ErrorResult(Messages.ProductHasNoStocksLeft);
                userBasketProductToAdd.Quantity = newQuantity;
                _userBasketProductDal.Update(userBasketProductToAdd);
            }
            return new SuccessResult(Messages.ProductAddedToBasket);
        }

        public IResult DeleteProductFromBasket(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var userBasket = _userBasketService.GetUserBasket(userId);
            var deleteProductToBasket = _userBasketProductDal.Get(i => i.Id == id && i.UserBasketId == userBasket.Data.Id);
            if (deleteProductToBasket == null) return new ErrorResult(Messages.UserBasketProductCanNotDelete);
            _userBasketProductDal.Delete(deleteProductToBasket);
            return new SuccessResult(Messages.UserBasketProductDeleted);
        }

        public IDataResult<List<UserBasketProductsForListingDTO>> GetAllProductsFromBasket()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _userBasketProductDal.GetAllProductInUserBasket(userId);
            return new SuccessDataResult<List<UserBasketProductsForListingDTO>>(result);
        }
        public IResult UpdateProductFromBasket(UserBasketProductsForUpdateDTO userBasketProduct)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var userBasket = _userBasketService.GetUserBasket(userId);
            UserBasketProduct userBasketProductToUpdate = _userBasketProductDal.Get(i => i.UserBasketId == userBasket.Data.Id && i.Id == userBasketProduct.Id);
            if (userBasketProductToUpdate == null) return new ErrorResult(Messages.UserBasketProductNotFound);
            var productToAdd = GetIfProductExists(userBasketProductToUpdate.ProductId);

            if (!productToAdd.Success) return new ErrorResult(Messages.ProductNotFound);
            if (!ProductHasStocks(productToAdd.Data, userBasketProduct.Quantity).Success) return new ErrorResult(Messages.ProductHasNoStocksLeft);
            userBasketProductToUpdate.Quantity = userBasketProduct.Quantity;
            _userBasketProductDal.Update(userBasketProductToUpdate);
            return new SuccessResult(Messages.UserBasketProductUpdated);
        }

        public IDataResult<UserBasketProduct> GetBasketItemByProductId(int productId)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var userBasket = _userBasketService.GetUserBasket(userId);
            var result = _userBasketProductDal.Get(i => i.ProductId == productId && i.UserBasketId == userBasket.Data.Id);
            if (result == null) return new ErrorDataResult<UserBasketProduct>();
            return new SuccessDataResult<UserBasketProduct>(result);
        }
        #region Business Rules
        private IDataResult<Product> GetIfProductExists(int productId)
        {
            var result = _productService.GetProductById(productId);
            if (!result.Success) return new ErrorDataResult<Product>(Messages.ProductNotFound);
            return new SuccessDataResult<Product>(result.Data);
        }
        private IResult ProductHasStocks(Product product, int quantity)
        {
            if (product.UnitsInStock < quantity) return new ErrorResult(Messages.ProductHasNoStocksLeft);
            return new SuccessResult();
        }
        #endregion
    }
}
