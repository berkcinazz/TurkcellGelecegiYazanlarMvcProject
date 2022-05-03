using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using Core.Utilities.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Business

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<OrderProductManager>().As<IOrderProductService>().SingleInstance();
            builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductReviewManager>().As<IProductReviewService>().SingleInstance();
            builder.RegisterType<UserBasketProductManager>().As<IUserBasketProductService>().SingleInstance();
            builder.RegisterType<UserBasketManager>().As<IUserBasketService>().SingleInstance();
            builder.RegisterType<UserFavoriteManager>().As<IUserFavoriteService>().SingleInstance();


            //DataAccess

            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<EfOrderProductDal>().As<IOrderProductDal>().SingleInstance();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<EfProductReviewDal>().As<IProductReviewDal>().SingleInstance();
            builder.RegisterType<EfUserBasketDal>().As<IUserBasketDal>().SingleInstance();
            builder.RegisterType<EfUserBasketProductDal>().As<IUserBasketProductDal>().SingleInstance();
            builder.RegisterType<EfUserFavoriteDal>().As<IUserFavoriteDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            
            //Others
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtTokenHelper>().As<ITokenHelper>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                        .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                        {
                            Selector = new AspectInterceptorSelector()
                        }).SingleInstance();
        }
    }
}
