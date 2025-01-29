using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApp.Services.Models;

namespace MoviesApp.Services.Contexts
{
    public class MoviesContext : DbContext
    {
        private readonly string? connectionString;

        public MoviesContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SSADbConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("SSADbConnection");
            }
        }

        public DbSet<Movie> Movies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("SSA.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateDummyData(modelBuilder);
        }

        private void CreateDummyData(ModelBuilder modelBuilder)
        {
            /*
             modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1,
                    Code = Core.Domain.Enums.Roles.LEADER,
                    Name = "Leader",
                    Created = DateTime.Now,
                    CreatedBy = "admin",
                    Updated = DateTime.Now,
                    UpdatedBy = "admin"
                },
                new Role
                {
                    RoleID = 2,
                    Code = Core.Domain.Enums.Roles.BELIEVER,
                    Name = "Believer",
                    Created = DateTime.Now,
                    CreatedBy = "admin",
                    Updated = DateTime.Now,
                    UpdatedBy = "admin"
                }
            );
             */
        }
    }
}
