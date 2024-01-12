using AdvaTask.Bll.Employees.Repository;
using AdvaTask.Bll.Employees.Service;
using AdvaTask.DAL;
using AdvaTask.DTO.Employee;
using AdvaTask.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdvaTask.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly AdvaTaskContext _context;

        public EmployeeController(IEmployeeService employeeService , AdvaTaskContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(EmployeeSearchDTO searchDTO)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(searchDTO);
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Salary,DepartmentId,ManagerId")] CreateEmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                 await _employeeService.CreateEmployeeAsync(employeeDTO);
              
                 return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employeeDTO.DepartmentId);
            return View(employeeDTO);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,DepartmentId,ManagerId")] UpdateEmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateEmployeeAsync(employeeDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employeeDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employeeDTO.DepartmentId);
            return View(employeeDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
