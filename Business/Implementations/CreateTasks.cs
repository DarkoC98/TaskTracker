using Business.DTO;
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
    public class CreateTasks : ICreateTask
    {
        public void CreateTask(TaskTrackerContext context, TaskDto dto)
        {
            Tasks tasksForInsert = new Tasks();
            tasksForInsert.Name = dto.Name;
            tasksForInsert.Description = dto.Description;
            tasksForInsert.Priority = dto.Priority;
            tasksForInsert.ProjectId = dto.ProjectId;
            tasksForInsert.Status = dto.Status;

           
            
                context.tasks.Add(tasksForInsert);
                context.SaveChanges();
                
            
            

        }
    }
}
