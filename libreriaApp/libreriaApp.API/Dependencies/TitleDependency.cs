using libreriaApp.BLL.Contracts;
using libreriaApp.BLL.Services;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace libreriaApp.API.Dependencies
{
    public static class TitleDependency
    {
        public static void AddTitleDependency(this IServiceCollection services)
        {
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddTransient<ITitleService, TitleService>();
        }
    }
}
