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
   public class GetTaskById : IGetTaskById
    {
        public ExecutionResult getTaskById(TaskTrackerContext context, int id)
        {
            TaskDto dto = new TaskDto();
            ExecutionResult exec = new ExecutionResult();


            var tasks = context.tasks.AsQueryable();
            var projects = context.projects.AsQueryable();
            var existingTaskQuery = (from t in tasks
                                     where t.Id == id
                                     join p in projects on t.ProjectId equals p.Id
                                     select new
                                     {
                                         TaskId = t.Id,
                                         TaskName = t.Name,
                                         TaskDescription = t.Description,
                                         TaskPriority = t.Priority,
                                         TaskProjectId = t.ProjectId,
                                         ProjectName = p.Name,
                                         TaskStatus = t.Status

                                     }).ToList();

            
            var existingTask = existingTaskQuery.FirstOrDefault();
            if(existingTask != null)
            {
                var data = tasks.Select(t => new TaskDto
                {
                    Id = existingTask.TaskId,
                    Name = existingTask.TaskName,
                    Description = existingTask.TaskDescription,
                    Priority = existingTask.TaskPriority,
                    ProjectId = existingTask.TaskProjectId,
                    ProjectName = existingTask.ProjectName,
                    Status = existingTask.TaskStatus
                }).ToList();
                exec.Data = data;
                return exec;


            }
            else
            {
                exec.Error.Add("There is no task with such id");
                return exec;
            }



                
            }
            
        }
    }

