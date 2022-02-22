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
using Microsoft.EntityFrameworkCore;

namespace Business.Implementations
{
    public class PutProject : IPutProject
    {
        public ExecutionResult PutProjects(TaskTrackerContext context, ProjectDto dto, int id)
        {
            ExecutionResult exec = new ExecutionResult();
            var existingProjectQuery = from projects in context.projects
                                    where projects.Id == id
                                    select projects;

            var existingProject = existingProjectQuery.FirstOrDefault();

            if(existingProject != null) 
            { 
                existingProject.Name = dto.Name;
                existingProject.StartDate = dto.StartDate;
                existingProject.EndDate = dto.EndDate;
                existingProject.Status = dto.Status;
                existingProject.ModifiedAt = DateTime.Now;
                existingProject.Priority = dto.Priority;
                context.Entry(existingProject).State = EntityState.Modified;
                exec.Message.Add("Project is successfuly modified");
                context.SaveChanges();
                return exec;
            }
            else
            {
                Project projectForInsert = new Project();
                projectForInsert.Name = dto.Name;
                projectForInsert.StartDate = dto.StartDate;
                projectForInsert.EndDate = dto.EndDate;
                projectForInsert.Status = dto.Status;
                projectForInsert.CreatedAt = DateTime.Now;
                context.projects.Add(projectForInsert);
                exec.Message.Add("Project is successfuly created");
                context.SaveChanges();
                return exec;
            }
            
        }
    }
}
