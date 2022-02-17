using Business.Interface;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class DeleteTask : IDeleteTask
    {
        public void Execute(TaskTrackerContext context, int id)
        {

            var taskForDeletion = (from tasks in context.tasks
                                  where tasks.Id == id
                                  select tasks).FirstOrDefault();

            context.tasks.Remove(taskForDeletion);
            context.SaveChanges();
        }
    }
}
