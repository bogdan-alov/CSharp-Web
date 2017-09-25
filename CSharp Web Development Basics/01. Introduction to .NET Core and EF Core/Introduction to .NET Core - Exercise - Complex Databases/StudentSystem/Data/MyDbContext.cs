using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class MyDbContext : DbContext
    {

	    public DbSet<Student> Students { get; set; }

	    public DbSet<StudentCourse> StudentCourses { get; set; }

	    public DbSet<Resource> Resources { get; set; }

	    public DbSet<Homework> Homeworks { get; set; }

	    public DbSet<Course> Courses { get; set; }

	    public DbSet<License> Licenses { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
			optionsBuilder.UseSqlServer(@"Server=.;Database=StudentSystemDB;Integrated Security=True");
		}

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Student>().HasMany(c => c.Courses).WithOne(c => c.Student).HasForeignKey(c => c.StudentId)
			    .OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<Course>().HasMany(c => c.Students).WithOne(c => c.Course).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<StudentCourse>().HasKey(c => new {c.CourseId, c.StudentId});

		    modelBuilder.Entity<Homework>().HasOne(c => c.Student).WithMany(c => c.Homeworks).HasForeignKey(c => c.StudentId)
			    .OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<Homework>().HasOne(c => c.Course).WithMany(c => c.Homeworks).HasForeignKey(c => c.CourseId)
			    .OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<Resource>().HasOne(c => c.Course).WithMany(c => c.Resources).HasForeignKey(c => c.CourseId)
			    .OnDelete(DeleteBehavior.Restrict);

		    modelBuilder.Entity<License>().HasOne(c => c.Resource).WithMany(c => c.Licenses).HasForeignKey(c => c.ResourceId)
			    .OnDelete(DeleteBehavior.Cascade);
	    }
    }
}
