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
                                     select new TaskDto
                                     {
                                         Id = t.Id,
                                         Name = t.Name,
                                         Description = t.Description,
                                         Priority = t.Priority,
                                         ProjectId = t.ProjectId,
                                         ProjectName = p.Name,
                                         Status = t.Status

                                     }).ToList();

            
            
            if(existingTaskQuery != null)
            {
                
                exec.Data = existingTaskQuery;
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

