using Microsoft.EntityFrameworkCore;
using FunTogether.Models;

namespace FunTogether.Data
{
    public class FunTogetherContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<ActivityFilter> ActivityFilters { get; set; }
        public FunTogetherContext(DbContextOptions<FunTogetherContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
