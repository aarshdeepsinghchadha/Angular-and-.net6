using Microsoft.EntityFrameworkCore;
using MVCDemo.Models.Domain;

namespace MVCDemo.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
