using AdvaTask.Bll.Departments.Repository;
using AdvaTask.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Department.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public  Task CreateDepartmentAsync(CreateDepartmentDTO departmentDTO)
        {
            if(departmentDTO == null)
            {
                throw new ArgumentNullException("Enter the information");            }
            return  _departmentRepository.CreateDepartmentAsync(departmentDTO);

        }

        public Task DeleteDepartmentAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException("id should be a value");
            }
            return _departmentRepository.DeleteDepartmentAsync(id);

        }

        public Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            return _departmentRepository.GetAllDepartmentsAsync();
        }

        public Task<Tables.Department> GetDepartmentByIdAsync(int id)
        {
           if( id == 0)
            {
                throw new ArgumentNullException("id should be a value");
            }
           return _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public Task UpdateDepartmentAsync(UpdateDepartmentDTO departmentDTO)
        {
            if(departmentDTO == null)
            {
                throw new ArgumentNullException("Enter the information");
            }
            return _departmentRepository.UpdateDepartmentAsync(departmentDTO);
        }
    }
}
