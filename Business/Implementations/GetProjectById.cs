using Business.DTO;
using Business.Interface;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class GetProjectById : IGetProjectById
    {
        public object getProjectsById(TaskTrackerContext context, int id)
        {
            ProjectFilterDto dto = new ProjectFilterDto();

            var existingProjectQuery = from projects in context.projects
                                       where projects.Id == id
                                       select projects;
            var existingProject = existingProjectQuery.FirstOrDefault();

            dto.Name = existingProject.Name;
            dto.StartDate = existingProject.StartDate;
            dto.EndDate = existingProject.EndDate;
            dto.Status = existingProject.Status;
            dto.Priority = existingProject.Priority;

            return dto;

            



        }
    }
}
