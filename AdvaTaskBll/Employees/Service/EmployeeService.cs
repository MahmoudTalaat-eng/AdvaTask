using AdvaTask.Bll.Employees.Repository;
using AdvaTask.DTO.Employee;
using AdvaTask.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Employees.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task CreateEmployeeAsync(CreateEmployeeDTO employeeDTO)
        {
            if(employeeDTO == null) 
            {
                throw new ArgumentNullException("nullvalue");
            }
            return _employeeRepository.CreateEmployeeAsync(employeeDTO);
        }

        public Task DeleteEmployeeAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException("id");
            }
            return _employeeRepository.DeleteEmployeeAsync(id);
        }

        public Task<List<Employee>> GetAllEmployeesAsync(EmployeeSearchDTO searchDTO)
        {
            if (searchDTO == null)
            {
                throw new ArgumentNullException("noooo");
            }    

            return _employeeRepository.GetAllEmployeesAsync(searchDTO);

        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException("id");
            }
            return _employeeRepository.GetEmployeeByIdAsync(id);

        }

        public Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO)
        {
            if(employeeDTO == null)
            {
                throw new ArgumentNullException("no data");
            }

            return _employeeRepository.UpdateEmployeeAsync(employeeDTO);
        }
    }
}
