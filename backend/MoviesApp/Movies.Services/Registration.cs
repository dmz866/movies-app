using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;

namespace Movies.Services
{
    public static class Registration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MoviesDbConnection");

            services.AddDbContext<MoviesContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            services.AddTransient<IMovieService, MovieService>(provider => new MovieService(provider.GetRequiredService<MoviesContext>(), provider.GetRequiredService<IMovieRatingService>()));
            services.AddTransient<IActorService, ActorService>(provider => new ActorService(provider.GetRequiredService<MoviesContext>()));
            services.AddTransient<IMovieRatingService, MovieRatingService>(provider => new MovieRatingService(provider.GetRequiredService<MoviesContext>()));
        }
    }
}
