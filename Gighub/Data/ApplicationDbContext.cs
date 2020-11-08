using Gighub.Data.Configurations;
using Gighub.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gighub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Gig> Gigs { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new GigConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());


            base.OnModelCreating(modelBuilder);
            modelBuilder.LowerCaseTablesAndFields();
        }
    }
}
