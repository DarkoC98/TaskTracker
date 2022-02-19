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
    public class CreateTasks : ICreateTask
    {
        public ExecutionResult CreateTask(TaskTrackerContext context, TaskDto dto)
        {
            ExecutionResult exec = new ExecutionResult();
            Tasks tasksForInsert = new Tasks();

            if (!String.IsNullOrEmpty(dto.Name))
            {
                tasksForInsert.Name = dto.Name;

            }
            else
            {
                exec.Error.Add("Name cant be empty");
                return exec;
            }

            if (!String.IsNullOrEmpty(dto.Description))
            {
                tasksForInsert.Description = dto.Description;

            }
            else
            {
                exec.Error.Add("Description cant be empty");
                return exec;
            }

            if (!String.IsNullOrEmpty(dto.Priority))
            {
                tasksForInsert.Priority = dto.Priority;
            }
            else
            {
                exec.Error.Add("Priority cant be empty");
                return exec;
            }


            if (dto.ProjectId != null)
            {
                tasksForInsert.ProjectId = dto.ProjectId;
            }
            else
            {
                exec.Error.Add("Task cant be empty");
                return exec;
            }

            if (dto.Status != null)
            {
                tasksForInsert.Status = dto.Status;
            }
            else
            {
                exec.Error.Add("Status cant be empty");
                return exec;
            }


            if (tasksForInsert != null)
            {
                context.tasks.Add(tasksForInsert);
                context.SaveChanges();
                exec.Message.Add("Successfully created task");
                return exec;
            }
            else
            {
                exec.Error.Add("Bad request");
                return exec;
            }



            //tasksForInsert.Name = dto.Name;
            //tasksForInsert.Description = dto.Description;
            //tasksForInsert.Priority = dto.Priority;
            //tasksForInsert.ProjectId = dto.ProjectId;
            //tasksForInsert.Status = dto.Status;



            //    context.tasks.Add(tasksForInsert);
            //    context.SaveChanges();




        }
    }
}
