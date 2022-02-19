using Business.DTO;
using Business.Execution;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IGetAllTasksForOneProject
    {
        public ExecutionResult getAllTasksForProject(TaskTrackerContext context, int id);
    }
}
