using System.Collections.Generic;
using System.Threading.Tasks;
using MicrodevProject.Models;
using MicrodevProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MicrodevProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // GET: Employee
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _service.GetAllEmploeeysAsync();
            return View(employees);
        }
        // GET: Employee/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _service.GetEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // GET: Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Bosses = _service.GetDropDownEmployees();
            ViewBag.Departments = _service.GetDropDownDepartments();
            return View();
        }
        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        // GET: Employee/Edit/5
        [Authorize(Policy = "EmployeeOnly")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _service.GetEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Bosses = _service.GetDropDownEmployees();
            ViewBag.Departments = _service.GetDropDownDepartments();
            return View(employee);
        }
        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(employee);
                return View(employee);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _service.GetEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            var isBoos = await _service.IsBoos(employee.EmployeeId);
            if (isBoos)
            {
                return View("DeleteFaild", employee);
            }
            return View(employee);
        }
        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteConfirmedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}