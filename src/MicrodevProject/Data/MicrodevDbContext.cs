using MicrodevProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicrodevProject.Data
{
    public class MicrodevDbContext : IdentityDbContext<User>
    {
        public MicrodevDbContext(DbContextOptions<MicrodevDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
