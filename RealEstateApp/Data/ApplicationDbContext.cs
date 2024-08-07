using Microsoft.EntityFrameworkCore;
using RealEstateApp.Models;
using System;

namespace RealEstateApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        private readonly string _defaultConnection;

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; } // Assuming you have a Subscriptions entity
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImages> PropertyImages { get; set; }
        public DbSet<UserLikedProperty> UserLikedProperty { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            //_configuration = configuration;
            _defaultConnection = configuration.GetConnectionString("DefaultConnection");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_defaultConnection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.NumOfAddedPropertys)
                .HasDefaultValue(0); // Fluent API

            modelBuilder.Entity<User>()
           .Property(u => u.Subscription_id)
           .HasDefaultValue(1); // Assuming '1' is the default SubscriptionId

            base.OnModelCreating(modelBuilder);
        }
    
    }
}
