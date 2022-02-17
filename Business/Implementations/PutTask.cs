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
    public class PutTask : IPutTask
    {
        public void PutTasks(TaskTrackerContext context, PutTaskDto dto, int id)
        {
            var existingTaskQuery = from tasks in context.tasks
                                    where tasks.Id == id
                                    select tasks;

            var existingTask = existingTaskQuery.FirstOrDefault();


            if (existingTask != null)
            {
                existingTask.Name = dto.Name;
                existingTask.Description = dto.Description;
                existingTask.Priority = dto.Priority;
                existingTask.ProjectId = dto.ProjectId;
                existingTask.ProjectId = dto.ProjectId;
            }
            else
            {
                
                Tasks taskForInsert = new Tasks();
                taskForInsert.Name = dto.Name;
                taskForInsert.Description = dto.Description;
                taskForInsert.Priority = dto.Priority;
                taskForInsert.ProjectId = dto.ProjectId;
                taskForInsert.ProjectId = dto.ProjectId;
                context.tasks.Add(taskForInsert);
            }
            context.SaveChanges();
        }
    }
}
