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
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Following> Followings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new GigConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new FollowingConfiguration());


            base.OnModelCreating(modelBuilder);
            modelBuilder.LowerCaseTablesAndFields();
        }
    }
}
