using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Commands.Movies.CreateMovie;

namespace Movies.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMovieCommandHandler).Assembly));
        }
    }
}
