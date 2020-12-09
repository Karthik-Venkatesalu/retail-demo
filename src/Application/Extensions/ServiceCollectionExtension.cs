using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(Order.Interfaces.IRequestHandler), typeof(Order.RequestHandler));
            services.AddTransient(typeof(Product.Interfaces.IRequestHandler), typeof(Product.RequestHandler));
        }
    }
}
