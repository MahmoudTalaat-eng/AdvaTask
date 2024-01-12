using AdvaTask.Bll.Department.Service;
using AdvaTask.Bll.Departments.Repository;
using AdvaTask.DAL;
using AdvaTask.DTO.Department;
using AdvaTask.DTO.Employee;
using AdvaTask.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvaTask.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly AdvaTaskContext _context;

        public DepartmentController(IDepartmentService departmentService  , AdvaTaskContext context)
        {
            _departmentService = departmentService;
            _context = context;
        }
        public async Task<ActionResult> IndexAsync()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CreateDepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {

                await _departmentService.CreateDepartmentAsync(departmentDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(departmentDTO);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ManagerId")] UpdateDepartmentDTO departmentDTO)
        {
            if (id != departmentDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await _departmentService.UpdateDepartmentAsync(departmentDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(departmentDTO.Id))
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
            return View(departmentDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(m => m.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }


    }
}
