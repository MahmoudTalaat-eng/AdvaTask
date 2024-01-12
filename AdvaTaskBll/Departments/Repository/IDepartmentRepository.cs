using AdvaTask.DTO.Department;
using AdvaTask.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.Bll.Departments.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<Tables.Department> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(CreateDepartmentDTO departmentDTO);
        Task UpdateDepartmentAsync(UpdateDepartmentDTO departmentDTO);
        Task DeleteDepartmentAsync(int id);
    }
}
