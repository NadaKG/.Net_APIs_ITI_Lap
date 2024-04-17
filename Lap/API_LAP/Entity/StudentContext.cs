using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Entity
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; Database = Studentss ; Trusted_Connection = True ; Encrypt = False");
            //base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Course> courses { get; set; }

    }
}
