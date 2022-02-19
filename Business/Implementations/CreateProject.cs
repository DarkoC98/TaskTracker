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
    public class CreateProject : ICreateProject
    {
        public ExecutionResult CreateProjects(TaskTrackerContext context, ProjectDto dto)
        {
            ExecutionResult exec = new ExecutionResult();
            Project projectsForInsert = new Project();
            if (!String.IsNullOrEmpty(dto.Name))
            {
                projectsForInsert.Name = dto.Name;
                
            }
            else
            {
                exec.Error.Add("Name cant be empty");
                return exec;
            }
            
            if (dto.StartDate != null)
            {
                projectsForInsert.StartDate = dto.StartDate;
                
            }
            else
            {
                exec.Error.Add("Start Date cant be empty");
                return exec;
            }
            
            if (dto.EndDate > dto.StartDate)
            {
                projectsForInsert.EndDate = dto.EndDate;
            }
            else
            {
                exec.Error.Add("End Date has to be after Start Date");
                return exec;
            }
            

            if (dto.Status >=0 && Convert.ToInt32(dto.Status) <= 2)
            {
                projectsForInsert.Status = dto.Status;
            }
            else
            {
                exec.Error.Add("Status has to be in range from 0 to 2");
                return exec;
            }
            
            projectsForInsert.Priority= dto.Priority;


            if (projectsForInsert != null)
            {
                context.projects.Add(projectsForInsert);
                context.SaveChanges();
                exec.Message.Add("Successfuly created project");
                return exec;
            }
            else
            {
                exec.Error.Add("Bad request");
                return exec;
            }


        }
    }
}
