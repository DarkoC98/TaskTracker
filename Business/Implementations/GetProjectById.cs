using Business.DTO;
using Business.Execution;
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
        public ExecutionResult getProjectsById(TaskTrackerContext context, int id)
        {
            ExecutionResult exec = new ExecutionResult();

            var projects = context.projects.AsQueryable();
            var existingProjectQuery = from p in projects
                                       where p.Id == id
                                       select p;
            var existingProject = existingProjectQuery.FirstOrDefault();

            if(existingProject != null)
            {
                var data = projects.Select(p => new ProjectDto
                {
                    Name = existingProject.Name,
                    Status = existingProject.Status,
                    StartDate = existingProject.StartDate,
                    EndDate = existingProject.EndDate,
                    Priority = existingProject.Priority
                }).ToList();
                exec.Data = data;
                return exec;
                
            }
            else
            {
                exec.Error.Add("There is not such project");
                return exec;
            }
            


            

            

            



        }
    }
}
