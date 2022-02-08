using Business.Interface;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
   public class GetTaskById : IGetTaskById
    {
        public IQueryable getTaskById(TaskTrackerContext context, int id)
        {
            var existingTaskQuery = from task in context.tasks
                                    where task.Id == id
                                    select task;

            var existingTask = existingTaskQuery;
            return existingTask;
        }
    }
}
