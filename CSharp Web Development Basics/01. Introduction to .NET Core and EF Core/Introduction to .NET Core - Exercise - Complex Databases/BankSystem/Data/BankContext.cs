using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Data
{
    class BankContext : DbContext
    {
	    public virtual DbSet<User> Users { get; set; }

	    public virtual DbSet<SavingAccount> SavingAccounts { get; set; }

	    public virtual DbSet<CheckingAccount> CheckingAccounts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=BankSystemDB;Integrated Security=True");
		}

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<User>().HasMany(c => c.CheckingAccounts).WithOne(c => c.User).HasForeignKey(c => c.UserId);
		    modelBuilder.Entity<User>().HasMany(c => c.SavingAccounts).WithOne(c => c.User).HasForeignKey(c => c.UserId);

	    }
    }
}
