using Business.Execution;
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
        public ExecutionResult Execute(TaskTrackerContext context, int id)
        {
            ExecutionResult exec = new ExecutionResult();

            var taskForDeletion = (from tasks in context.tasks
                                  where tasks.Id == id
                                  select tasks).FirstOrDefault();

            if (taskForDeletion == null)
            {

                exec.Error.Add("There is no task with that id");
                return exec;
            }
            else
            {
                context.tasks.Remove(taskForDeletion);
                context.SaveChanges();
                exec.Message.Add("Successfuly deleted task");
                return exec;
            }
            
        }
    }
}
