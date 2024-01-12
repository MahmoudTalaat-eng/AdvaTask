using AdvaTask.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Department.Service
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<Tables.Department> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(CreateDepartmentDTO departmentDTO);
        Task UpdateDepartmentAsync(UpdateDepartmentDTO departmentDTO);
        Task DeleteDepartmentAsync(int id);
    }
}
