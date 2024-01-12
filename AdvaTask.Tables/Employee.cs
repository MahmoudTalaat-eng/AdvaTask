using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvaTask.Tables
{
    public class Employee : BaseEntity
    {
        public decimal Salary { get; set; }
        [ForeignKey(nameof(ManagerId))]    
        public int? ManagerId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public int? DepartmentId { get; set; }
        public Employee? Manager { get; set; }
        public Department Department { get; set; }
    }
}
