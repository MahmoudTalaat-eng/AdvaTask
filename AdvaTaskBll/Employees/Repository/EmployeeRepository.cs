using AdvaTask.DAL;
using AdvaTask.DTO.Employee;
using AdvaTask.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Employees.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AdvaTaskContext _context;

        public EmployeeRepository(AdvaTaskContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDTO employeeDTO)
        {
            var employee = new Employee()
            {
                Name = employeeDTO.Name,
                DepartmentId = employeeDTO.DepartmentId,
                ManagerId = employeeDTO.ManagerId,
                Salary = employeeDTO.Salary
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(EmployeeSearchDTO searchDTO)
        {
            if (searchDTO.Name != null)
            {
                return await _context.Employees.Include(b => b.Department).Where(a => a.Name.Contains(searchDTO.Name)).ToListAsync();
            }
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

   

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("error");  //note that
            }

             return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            

        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO)
        {
            var existEmployee = await _context.Employees.FirstOrDefaultAsync(a =>  a.Id == employeeDTO.Id);
           
            existEmployee.Id = employeeDTO.Id;
            existEmployee.Name = employeeDTO.Name;
            existEmployee.Salary = employeeDTO.Salary;
            existEmployee.DepartmentId = existEmployee.DepartmentId;
            existEmployee.ManagerId = existEmployee.ManagerId;


            _context.Employees.Update(existEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
