﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvaTask.DTO.Department
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }

    }
}
