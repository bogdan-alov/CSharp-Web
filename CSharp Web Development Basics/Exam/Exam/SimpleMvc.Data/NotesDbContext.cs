using Microsoft.EntityFrameworkCore;
using SimpleMvc.Data.Models;

namespace SimpleMvc.Data
{
    public class NotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NotesDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}