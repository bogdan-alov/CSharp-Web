using Microsoft.EntityFrameworkCore;

namespace _02.One_To_Many_Relation
{
    public class MyContext : DbContext
    {
	    public DbSet<Employee> Employees { get; set; }

	    public DbSet<Department> Departments { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder builder)
	    {
		    builder.UseSqlServer(@"Server=.;Database=MyDB;Integrated security=True;");
	    }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    builder.Entity<Employee>().HasOne(e => e.Department)
				.WithMany(d => d.Employees)
			    .HasForeignKey(e => e.DepartmentId);
	    }
    }
}
