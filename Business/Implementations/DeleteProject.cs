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
    public class DeleteProject : IDeleteProject
    {
        public ExecutionResult Execute(TaskTrackerContext context, int id)
        {
            ExecutionResult exec = new ExecutionResult();

            var projectForDeletion = (from projects in context.projects
                                   where projects.Id == id
                                   select projects).FirstOrDefault();

            if(projectForDeletion == null)
            {
                
                exec.Error.Add("There is no project with that id");
                return exec;
            }
            else
            {
                projectForDeletion.DeletedAt = DateTime.Now;
                context.projects.Remove(projectForDeletion);
                context.SaveChanges();
                exec.Message.Add("Successfully deleted");
                return exec;
            }


          
        }
    }
}
