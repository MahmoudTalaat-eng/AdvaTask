using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvaTask.Tables
{
    public class Department : BaseEntity
    {
       
        public ICollection<Employee>? Employees { get; set; }



    }
}
