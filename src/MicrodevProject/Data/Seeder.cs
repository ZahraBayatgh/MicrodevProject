using MicrodevProject.Data;
using MicrodevProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MicrodevProject.Data
{
    public class Seeder
    {
        private readonly MicrodevDbContext _context;
        private readonly UserManager<User> _userManager;
        public Seeder(MicrodevDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task Seed()
        {
            _context.Database.EnsureCreated();
            var user = await _userManager.FindByEmailAsync("BytZahra@Gmail.com");
            if (user == null)
            {
                user = new User()
                {
                    FirstName = "Zahra",
                    LastName = "Bayat",
                    UserName = "BytZahra@Gmail.com",
                    Email = "BytZahra@Gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }
            if (!_context.Departments.Any())
            {
                List<Department> departments = new List<Department>
                {
                new Department{Name="مدیریت روشمند "},
                new Department{Name="دکان باز "},
                new Department{Name="ایده پرداز "},
                };
                _context.Departments.AddRange(departments);
            }
            if (!_context.Employees.Any())
            {
                List<Employee> employees = new List<Employee>
                {
                    new Employee {Name="زهرا بیات ", Salary=1000 ,BossId=3, DepartmentId=1 },
                    new Employee {Name="علی بیات ", Salary=3000 ,BossId=5, DepartmentId=2 },
                    new Employee {Name="امین مژگانی ", Salary=1000, BossId=4, DepartmentId=1 },
                    new Employee {Name="محمد سهیلی ", Salary = 4000,BossId = 1, DepartmentId = 1 },
                    new Employee {Name="سارا احمدی ", Salary=1000, BossId=4, DepartmentId=2 },
                    new Employee {Name="محمد سعیدی ", Salary=1000, BossId=4, DepartmentId=2 },
                    new Employee {Name="سهیلا افتخاری ", Salary=2000, BossId=4, DepartmentId=2 },
                    new Employee {Name="سعید حسینی ", Salary=5000, BossId=4, DepartmentId=3},
                    new Employee {Name="زهرا محمدی ", Salary=1000, BossId=8, DepartmentId=3 }
                };
                _context.Employees.AddRange(employees);
                _context.Employees.ToList();
            }
            await _context.SaveChangesAsync();
        }
    }
}