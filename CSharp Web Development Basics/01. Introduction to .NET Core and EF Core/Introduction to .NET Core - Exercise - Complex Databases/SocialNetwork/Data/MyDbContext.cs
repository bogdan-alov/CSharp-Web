using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Data
{
    class MyDbContext : DbContext
    {
		public DbSet<User> Users { get; set; }

	    public DbSet<Friend> Friends { get; set; }

	    public DbSet<Album> Albums { get; set; }

	    public DbSet<Picture> Pictures { get; set; }

	    public DbSet<AlbumPicture> AlbumPictures { get; set; }

	    public DbSet<TagAlbum> AlbumTags { get; set; }

	    public DbSet<Tag> Tags { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=SocialNetworkDB;Integrated Security=True");
		}

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Friend>().HasKey(c => new {c.FriendId, c.UserId});

		    modelBuilder.Entity<Friend>().HasOne(c => c.User).WithMany(c => c.Friends).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

		    modelBuilder.Entity<Friend>().HasOne(c => c.FriendUser).WithMany(c => c.Users).HasForeignKey(c => c.FriendId)
			    .OnDelete(DeleteBehavior.Cascade);

		    modelBuilder.Entity<AlbumPicture>().HasKey(c => new {c.AlbumId, c.PictureId});

		    modelBuilder.Entity<Album>().HasMany(c => c.Pictures).WithOne(c => c.Album).HasForeignKey(c => c.AlbumId).OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<Picture>().HasMany(c => c.Albums).WithOne(c => c.Picture).HasForeignKey(c => c.PictureId).OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<Album>().HasOne(c => c.User).WithMany(c => c.Albums).HasForeignKey(c => c.UserId);

		    modelBuilder.Entity<Album>().HasMany(c => c.Tags).WithOne(c => c.Album).HasForeignKey(c => c.AlbumId).OnDelete(DeleteBehavior.Cascade);

		    modelBuilder.Entity<Tag>().HasMany(c => c.Albums).WithOne(c => c.Tag).HasForeignKey(c => c.TagId).OnDelete(DeleteBehavior.Cascade);

		    modelBuilder.Entity<TagAlbum>().HasKey(c => new {c.AlbumId, c.TagId});
	    }
    }
}
