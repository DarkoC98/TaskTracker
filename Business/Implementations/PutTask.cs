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
    public class PutTask : IPutTask
    {
        public ExecutionResult PutTasks(TaskTrackerContext context, PutTaskDto dto, int id)
        {
            ExecutionResult exec = new ExecutionResult();
            var existingTaskQuery = from tasks in context.tasks
                                    where tasks.Id == id
                                    select tasks;

            var existingTask = existingTaskQuery.FirstOrDefault();

            if (existingTask != null)
            {
                if (!string.IsNullOrEmpty(dto.Name))
                {
                    existingTask.Name = dto.Name;
                }
                else
                {
                    exec.Error.Add("Name cant be empty");
                    return exec;
                }
                if (!string.IsNullOrEmpty(dto.Description))
                {
                    existingTask.Description = dto.Description;
                }
                else
                {
                    exec.Error.Add("Description cant be empty");
                    return exec;
                }
                if (!string.IsNullOrEmpty(dto.Priority))
                {
                    existingTask.Priority = dto.Priority;
                }
                else
                {
                    exec.Error.Add("Priority cant be empty");
                    return exec;
                }
                if (dto.ProjectId != null)
                {
                    existingTask.ProjectId = dto.ProjectId;
                }
                else
                {
                    exec.Error.Add("Project Id cant be empty");
                    return exec;
                }
                existingTask.ModifiedAt = DateTime.Now;
                exec.Message.Add("Task is successfuly modified");
                context.SaveChanges();
                return exec;
            }
            else
            {

                Tasks taskForInsert = new Tasks();
                if (!string.IsNullOrEmpty(dto.Name))
                {
                    taskForInsert.Name = dto.Name;
                }
                else
                {
                    exec.Error.Add("Name cant be empty");
                    return exec;
                }
                if (!string.IsNullOrEmpty(dto.Description))
                {
                    taskForInsert.Description = dto.Description;
                }
                else
                {
                    exec.Error.Add("Description cant be empty");
                    return exec;
                }
                if (!string.IsNullOrEmpty(dto.Priority))
                {
                    taskForInsert.Priority = dto.Priority;
                }
                else
                {
                    exec.Error.Add("Priority cant be empty");
                    return exec;
                }
                if (dto.ProjectId != null)
                {
                    taskForInsert.ProjectId = dto.ProjectId;
                }
                else
                {
                    exec.Error.Add("Project Id cant be empty");
                    return exec;
                }

                taskForInsert.ModifiedAt = DateTime.Now;
                context.tasks.Add(taskForInsert);
                exec.Message.Add("Task is successfuly created");
                context.SaveChanges();
                return exec;

            }

        }
    }
    
}

