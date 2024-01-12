using AdvaTask.DAL;
using AdvaTask.DTO.Department;
using AdvaTask.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Departments.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AdvaTaskContext _context;

        public DepartmentRepository(AdvaTaskContext context)
        {
            _context = context;
        }
        public async Task CreateDepartmentAsync(CreateDepartmentDTO departmentDTO)
        {
            var department = new Tables.Department()
            {
                Name = departmentDTO.Name,
            };
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            List<DepartmentDTO> departments = await _context.Departments
                        .Include(a => a.Employees)
                        .Select(a => new DepartmentDTO()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            ManagerId = a.Employees.FirstOrDefault().ManagerId,
                            ManagerName = a.Employees.FirstOrDefault().Name,
                        })
                        .ToListAsync();
            return departments;

        }

        public async Task<Tables.Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDTO departmentDTO)
        {
            var existDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentDTO.Id);
            existDepartment.Name = departmentDTO.Name;
            _context.Departments.Update(existDepartment);
            await _context.SaveChangesAsync();

        }
    }
}
