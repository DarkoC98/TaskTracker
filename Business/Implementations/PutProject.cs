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


            if (existingProject != null)
            {
                if(!string.IsNullOrEmpty(existingProject.Name))
                {
                    existingProject.Name = dto.Name;
                }
                else
                {
                    exec.Error.Add("Name cant be empty");
                    return exec;
                }
                if (existingProject.StartDate != null)
                {
                    existingProject.StartDate = dto.StartDate;
                }
                else
                {
                    exec.Error.Add("Start date cant be empty");
                    return exec;
                }
                if(existingProject.EndDate > existingProject.StartDate)
                {
                    existingProject.EndDate = dto.EndDate;
                }
                else
                {
                    exec.Error.Add("End date has to be after Start date");
                    return exec;
                }
                if(existingProject.Status >= 0 && Convert.ToInt32(existingProject.Status) <= 2)
                {
                    existingProject.Status = dto.Status;
                }
                else
                {
                    exec.Error.Add("Status has to be in range from 0 to 2");
                    return exec;
                }
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
                if (!string.IsNullOrEmpty(projectForInsert.Name))
                {
                    projectForInsert.Name = dto.Name;
                }
                else
                {
                    exec.Error.Add("Name cant be empty");
                    return exec;
                }
                if (projectForInsert.StartDate != null)
                {
                    projectForInsert.StartDate = dto.StartDate;
                }
                else
                {
                    exec.Error.Add("Start date cant be empty");
                    return exec;
                }
                if (projectForInsert.EndDate > projectForInsert.StartDate)
                {
                    projectForInsert.EndDate = dto.EndDate;
                }
                else
                {
                    exec.Error.Add("End date has to be after Start date");
                    return exec;
                }
                if (projectForInsert.Status >= 0 && Convert.ToInt32(projectForInsert.Status) <= 2)
                {
                    projectForInsert.Status = dto.Status;
                }
                else
                {
                    exec.Error.Add("Status has to be in range from 0 to 2");
                    return exec;
                }

                existingProject.CreatedAt = DateTime.Now;
                context.projects.Add(projectForInsert);
                exec.Message.Add("Project is successfuly created");
                context.SaveChanges();
                return exec;

            }
            
        }
    }
}
