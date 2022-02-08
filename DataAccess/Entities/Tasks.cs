using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public TasksStatus Status { get; set; }
    }

    public enum TasksStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
