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
            var existingProjectQuery = (from p in projects
                                        where p.Id == id
                                        select new ProjectDto
                                        {
                                            Name = p.Name,
                                            Status = p.Status,
                                            StartDate = p.StartDate,
                                            EndDate = p.EndDate,
                                            Priority = p.Priority
                                        }).ToList();

            if(existingProjectQuery != null)
            {
                exec.Data = existingProjectQuery;
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
