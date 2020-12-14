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
        }
    }
}
