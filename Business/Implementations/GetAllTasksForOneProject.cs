using Business.DTO;
using Business.Execution;
using Business.Interface;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class GetAllTasksForOneProject : IGetAllTasksForOneProject
    {
        public ExecutionResult getAllTasksForProject(TaskTrackerContext context, int id)
        {


            ExecutionResult exec = new ExecutionResult();

            var project = context.projects.Find(id);
            if(project == null)
            {
                exec.Error.Add("Project doesnt exist");
                return exec;
            }    

            var tasksForDisplay = context.tasks.Where(t => t.ProjectId == id).OrderBy(t => t.Priority).Select(t => new TaskDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                ProjectName = t.Project.Name,
                ProjectId = t.ProjectId
            });
            exec.Data = tasksForDisplay;
            return exec;
            
            
           
            
            
            







        }
    }
}
