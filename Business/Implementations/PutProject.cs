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
    public class PutProject : IPutProject
    {
        public void PutProjects(TaskTrackerContext context, ProjectDto dto, int id)
        {
            var existingProjectQuery = from projects in context.projects
                                    where projects.Id == id
                                    select projects;

            var existingProject = existingProjectQuery.FirstOrDefault();


            if (existingProject != null)
            {
                existingProject.Name = dto.Name;
                existingProject.StartDate = dto.StartDate;
                existingProject.EndDate = dto.EndDate;
                existingProject.Status = dto.Status;
                existingProject.Priority = dto.Priority;
            }
            else
            {

                Project projectForInsert = new Project();
                projectForInsert.Name = dto.Name;
                projectForInsert.StartDate = dto.StartDate;
                projectForInsert.EndDate = dto.EndDate;
                projectForInsert.Status = dto.Status;
                projectForInsert.Priority = dto.Priority;
                context.projects.Add(projectForInsert);
            }
            context.SaveChanges();
        }
    }
}
