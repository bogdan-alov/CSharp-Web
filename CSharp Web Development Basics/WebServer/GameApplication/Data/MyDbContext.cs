using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebServer.GameApplication.Models;

namespace WebServer.GameApplication.Data
{
    public class MyDbContext : DbContext
    {
	    public DbSet<User> Users { get; set; }

	    public DbSet<Game> Games { get; set; }

	    public DbSet<UserGame> UserGames { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseSqlServer(@"Server=.;Database=GameStore;Integrated Security=True");
	    }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
			builder
			    .Entity<UserGame>()
			    .HasKey(ug => new { ug.GameId, ug.UserId });

		    builder
			    .Entity<User>()
			    .HasIndex(u => u.Email)
			    .IsUnique();

		    builder
			    .Entity<User>()
			    .HasMany(u => u.Games)
			    .WithOne(ug => ug.User)
			    .HasForeignKey(ug => ug.UserId);

		    builder
			    .Entity<Game>()
			    .HasMany(g => g.Users)
			    .WithOne(ug => ug.Game)
			    .HasForeignKey(ug => ug.GameId);
		}
    }

}
