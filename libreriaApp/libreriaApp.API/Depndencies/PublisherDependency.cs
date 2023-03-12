using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Services;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace libreriaApp.API.Depndencies
{
    public static class PublisherDependency
    {
        public static void AddPublisherDependency(this IServiceCollection services)
        {
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IPublisherService, PublisherService>();

        }
    }
}
