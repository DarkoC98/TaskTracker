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
   public class GetTaskById : IGetTaskById
    {
        public object getTaskById(TaskTrackerContext context, int id)
        {
            TaskDto dto = new TaskDto();
            


            var existingTaskQuery = from task in context.tasks
                                    where task.Id == id
                                    join project in context.projects on task.ProjectId equals project.Id
                                    select new
                                    {
                                        TaskId = task.Id,
                                        TaskName = task.Name,
                                        TaskDescription = task.Description,
                                        TaskPriority = task.Priority,
                                        TaskProjectId = task.ProjectId,
                                        ProjectName = project.Name,
                                        TaskStatus = task.Status

                                    };

            
            var existingTask = existingTaskQuery.FirstOrDefault();



                dto.Id = existingTask.TaskId;
                dto.Name = existingTask.TaskName;
                dto.Description = existingTask.TaskDescription;
                dto.Priority = existingTask.TaskPriority;
                dto.ProjectId = existingTask.TaskProjectId;
                dto.ProjectName = existingTask.ProjectName;
                dto.Status = existingTask.TaskStatus;
                return dto;
            }
            
        }
    }

