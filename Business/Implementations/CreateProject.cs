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
    public class CreateProject : ICreateProject
    {
        public void CreateProjects(TaskTrackerContext context, ProjectDto dto)
        {
            Project projectsForInsert = new Project();
            projectsForInsert.Name = dto.Name;
            projectsForInsert.StartDate = dto.StartDate;
            projectsForInsert.EndDate = dto.EndDate;
            projectsForInsert.Status= dto.Status;
            projectsForInsert.Priority= dto.Priority;



            context.projects.Add(projectsForInsert);
            context.SaveChanges();
        }
    }
}
