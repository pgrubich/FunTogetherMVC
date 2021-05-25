using Microsoft.EntityFrameworkCore;
using FunTogether.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FunTogether.Data.Configuration;

namespace FunTogether.Data
{
    public class FunTogetherContext : IdentityDbContext<User>
    {
        public DbSet<Activity> Activities { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<ActivityFilter> ActivityFilters { get; set; }
        public FunTogetherContext(DbContextOptions<FunTogetherContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<UserActivity>().HasKey(ua => new { ua.UserId, ua.ActivityId });
            modelBuilder.Entity<ActivityFilter>().HasKey(af => new { af.ActivityId, af.FilterId });
            modelBuilder.Entity<Activity>().Property(a => a.Type).HasConversion<string>();
            modelBuilder.Entity<Filter>().Property(f => f.Category).HasConversion<string>();
            modelBuilder.Entity<Filter>().HasData(
                 new Filter() { Id = 1, Category = Filter.FilterCategory.AgeGroup, Value = "18-23" },
                 new Filter() { Id = 2, Category = Filter.FilterCategory.AgeGroup, Value = "24-29" },
                 new Filter() { Id = 3, Category = Filter.FilterCategory.AgeGroup, Value = "30-39" },
                 new Filter() { Id = 4, Category = Filter.FilterCategory.AgeGroup, Value = "40-49" },
                 new Filter() { Id = 5, Category = Filter.FilterCategory.AgeGroup, Value = "50+" },
                 new Filter() { Id = 6, Category = Filter.FilterCategory.Gender, Value = "Female" },
                 new Filter() { Id = 7, Category = Filter.FilterCategory.Gender, Value = "Male" });
           
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });           
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
