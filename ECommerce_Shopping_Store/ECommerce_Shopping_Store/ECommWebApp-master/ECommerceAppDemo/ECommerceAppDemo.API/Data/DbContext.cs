using System.Data.Entity;
using ECommerceAppDemo.API.Models;

namespace ECommerceAppDemo.API.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; } // Added DbSet for Cart
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public ECommerceDbContext() : base("name=ECommerceDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product_New");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Cart>().ToTable("Cart"); // Map Cart to the correct table
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails");
        }
    }
}