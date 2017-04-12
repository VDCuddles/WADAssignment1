using WADAssignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace WADAssignment1.Data
{
    public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{
		}
		public DbSet<Bag> Bags { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Bag>().ToTable("Bag");
			modelBuilder.Entity<Customer>().ToTable("Customer");
			modelBuilder.Entity<Order>().ToTable("Order");
			modelBuilder.Entity<Supplier>().ToTable("Supplier");
		}
	}
}




