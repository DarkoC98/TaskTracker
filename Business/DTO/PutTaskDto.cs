using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class PutTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public int ProjectId { get; set; }
        public TasksStatus Status { get; set; }
    }
}
