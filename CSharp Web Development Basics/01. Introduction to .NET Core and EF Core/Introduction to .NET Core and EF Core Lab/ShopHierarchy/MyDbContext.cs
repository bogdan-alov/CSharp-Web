using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShopHierarchy.Models;

namespace ShopHierarchy
{
    public class MyDbContext : DbContext
    {
	    public DbSet<Customer> Customers { get; set; }

	    public DbSet<Salesman> Salesmen { get; set; }

	    public DbSet<Order> Orders { get; set; }

	    public DbSet<Review> Reviews { get; set; }

	    public DbSet<Item> Items { get; set; }

	    public DbSet<OrderItems> OrderedItems { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
	    {
		    builder.UseSqlServer(@"Server=.;Database=ShopHierarchy;Integrated security=True;");
	    }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    builder.Entity<Customer>().HasOne(c => c.Salesman)
			    .WithMany(s=> s.Customers)
			    .HasForeignKey(c=> c.SalesmanId);

		    builder.Entity<Order>()
				.HasOne(o => o.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerId);

		    builder.Entity<OrderItems>().HasKey(sc => new { sc.ItemId, sc.OrderId });


			builder.Entity<Item>()
				.HasMany(i => i.Reviews)
				.WithOne(r => r.Item)
				.HasForeignKey(i => i.ItemId);


			builder.Entity<Item>()
			    .HasMany(s => s.Orders)
			    .WithOne(sc => sc.Item)
			    .HasForeignKey(s => s.OrderId).OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Order>()
				.HasMany(c => c.Items)
			    .WithOne(sc => sc.Order)
			    .HasForeignKey(c => c.ItemId).OnDelete(DeleteBehavior.Restrict);


			builder.Entity<Review>()
				.HasOne(r => r.Customer)
				.WithMany(c => c.Reviews)
				.HasForeignKey(r => r.CustomerId);


	    }
	}
}
