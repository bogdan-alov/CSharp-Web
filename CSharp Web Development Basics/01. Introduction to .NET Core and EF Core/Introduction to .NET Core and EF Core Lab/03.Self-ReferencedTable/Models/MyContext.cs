using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _03.Self_ReferencedTable
{
    public class MyContext : DbContext
    {
	    public DbSet<Employee> Employees { get; set; }

	    public DbSet<Department> Departments { get; set; }

	    public DbSet<Student> Students { get; set; }

	    public DbSet<Course> Courses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
	    {
		    builder.UseSqlServer(@"Server=.;Database=MyDB;Integrated security=True;");
	    }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    builder.Entity<Employee>().HasOne(e => e.Department)
				.WithMany(d => d.Employees)
			    .HasForeignKey(e => e.DepartmentId);

		    builder.Entity<Employee>().HasOne(e => e.Manager).WithMany(m => m.Employees).HasForeignKey(e => e.ManagerId).OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<StudentsCourses>().HasKey(sc => new {sc.CourseId, sc.StudentId});

		    builder.Entity<Student>()
				.HasMany(s => s.Courses)
				.WithOne(sc => sc.Student)
				.HasForeignKey(s => s.CourseId);

		    builder.Entity<Course>().HasMany(c => c.Students)
				.WithOne(sc => sc.Course)
				.HasForeignKey(c => c.StudentId);
	    }
    }
}
