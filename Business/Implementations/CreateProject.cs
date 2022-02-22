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
      
            projectsForInsert.Name = dto.Name;
            projectsForInsert.StartDate = dto.StartDate;
            projectsForInsert.EndDate = dto.EndDate;
            projectsForInsert.Status = dto.Status;
            projectsForInsert.Priority= dto.Priority;
            projectsForInsert.CreatedAt = DateTime.Now;
            context.projects.Add(projectsForInsert);
            context.SaveChanges();
            exec.Message.Add("Project created successfully");
            return exec;
            


        }
    }
}
