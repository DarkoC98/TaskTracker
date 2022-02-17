using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class TaskFilterDto
    {
        public string Name { get; set; }
        public TasksStatus Status { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
    }
}
