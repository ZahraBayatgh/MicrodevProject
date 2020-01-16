using MicrodevProject.Data;
using MicrodevProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrodevProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MicrodevDbContext _context;
        public EmployeeService(MicrodevDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmploeeysAsync()
        {
            return await _context.Employees.Include(x => x.Department).ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int? id)
        {
            return await _context.Employees.Include(x=>x.Department).Include(x=>x.Boss).FirstOrDefaultAsync(m => m.EmployeeId == id);
        }
        public IQueryable<SelectListItem> GetDropDownEmployees()
        {
            return _context.Employees.Select(x => new SelectListItem { Value = x.DepartmentId.ToString(), Text = x.Name });
        }
        public IQueryable<SelectListItem> GetDropDownDepartments()
        {
            return _context.Departments.Select(x => new SelectListItem { Value = x.DepartmentId.ToString(), Text = x.Name });
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task DeleteConfirmedAsync(int id)
        {
                var employee = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
          
        }
        public async Task<bool> IsBoos(int id)
        {
            var isBoos = await _context.Employees.AnyAsync(x=>x.BossId==id);
            return isBoos;
        }
    }

}
