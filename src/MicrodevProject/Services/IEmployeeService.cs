using MicrodevProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrodevProject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmploeeysAsync();
        Task<Employee> GetEmployeeAsync(int? id);
        IQueryable<SelectListItem> GetDropDownEmployees();
        IQueryable<SelectListItem> GetDropDownDepartments();
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task DeleteConfirmedAsync(int id);
        Task<bool> IsBoos(int id);

    }
}
