using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IFacade), typeof(Facade));
            services.AddSingleton(typeof(Application.Order.Interfaces.IRepository), typeof(Repositories.OrderRepository));
            services.AddSingleton(typeof(Application.Product.Interfaces.IRepository), typeof(Repositories.ProductRepository));
        }
    }
}
