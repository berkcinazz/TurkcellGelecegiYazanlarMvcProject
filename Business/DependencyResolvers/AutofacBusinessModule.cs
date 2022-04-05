using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Business

            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<PublisherManager>().As<IPublisherService>().SingleInstance();


            //DataAccess

            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                        .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                        {
                            Selector = new AspectInterceptorSelector()
                        }).SingleInstance();
        }
    }
}
