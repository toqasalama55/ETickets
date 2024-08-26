using ETickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using ETickets.Models.ViewModel;

namespace ETickets.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
      //  public DbSet<StripeSettings> StripeSettings { get; set; }
        // public DbSet<ActorsMovies> ActorsMovies { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public ApplicationDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, reloadOnChange: true)
                .Build();

            var connection = builder.GetConnectionString("DefaultConnetion");

            optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<ETickets.Models.ViewModel.RoleVM> RoleVM { get; set; } = default!;
        
        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<ActorsMovies>()
        //            .HasKey(am => new { am.ActorsId, am.MoviesId });
        //        // Relationships configuration
        //        modelBuilder.Entity<ActorsMovies>()
        //            .HasOne(am => am.Movies)
        //            .WithMany(m => m.ActorsMovies)
        //            .HasForeignKey(am => am.MoviesId);

        //        modelBuilder.Entity<ActorsMovies>()
        //            .HasOne(am => am.Actors)
        //            .WithMany(a => a.ActorsMovies)
        //            .HasForeignKey(am => am.ActorsId);
        //    }
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configure composite primary key for ActorsMovies
        //    modelBuilder.Entity<ActorsMovies>()
        //        .HasKey(am => new { am.MoviesId, am.ActorsId });

        //    // Configure relationship between Movies and ActorsMovies
        //    modelBuilder.Entity<ActorsMovies>()
        //        .HasOne(am => am.Movies)
        //        .WithMany(m => m.ActorsMovies)
        //        .HasForeignKey(am => am.MoviesId);

        //    // Configure relationship between Actors and ActorsMovies
        //    modelBuilder.Entity<ActorsMovies>()
        //        .HasOne(am => am.Actors)
        //        .WithMany(a => a.ActorsMovies)
        //        .HasForeignKey(am => am.ActorsId);
        //}

    }
}

