using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Unit_Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())//Microsoft.Extensions.Configuration.Json
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();
        }
    }
}
