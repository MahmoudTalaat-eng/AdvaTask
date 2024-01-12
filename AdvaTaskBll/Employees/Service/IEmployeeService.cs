using AdvaTask.DTO.Employee;
using AdvaTask.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Employees.Service
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync(EmployeeSearchDTO searchDTO);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(CreateEmployeeDTO employeeDTO);
        Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO);
        Task DeleteEmployeeAsync(int id);
    }
}
