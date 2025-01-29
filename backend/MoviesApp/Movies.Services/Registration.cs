using Microsoft.Extensions.DependencyInjection;
using Movies.Services;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;

namespace Movies.Services
{
    public static class Registration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>(provider => new MovieService(provider.GetRequiredService<MoviesContext>()));            
        }
    }
}
