using AdvaTask.DTO.Employee;
using AdvaTask.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Employees.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync(EmployeeSearchDTO searchDTO);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(CreateEmployeeDTO employeeDTO);
        Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO);
        Task DeleteEmployeeAsync(int id);
    }
}
