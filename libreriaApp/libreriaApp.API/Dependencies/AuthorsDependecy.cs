using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Services;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace libreriaApp.API.Dependencies
{
    public static class AuthorsDependecy
    {
        public static void AddAuthorsDependcy(this IServiceCollection services)
        {
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddTransient<IAuthorsService, AuthorsService>();
        }
    }
}
