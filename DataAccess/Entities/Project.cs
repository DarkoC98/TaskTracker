using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Project 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority{ get; set; }

        public ICollection<Tasks> Tasks { get; set; }
        public ProjectStatus Status { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
}
