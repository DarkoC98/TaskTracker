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
    public interface ICreateTask
    {
        public ExecutionResult CreateTask(TaskTrackerContext context, TaskDto dto);
    }
}
