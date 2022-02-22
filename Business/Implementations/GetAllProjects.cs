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
	public class GetAllProjects : IGetAllProjects
    {
		
        public ExecutionResult getAllProjects(TaskTrackerContext context, ProjectFilterDto filterDto)
        {
			ExecutionResult exec = new ExecutionResult();
            var projects = context.projects.AsQueryable();

			projects = projects.Where(p => p.Name.ToLower().Contains(filterDto.Name.ToLower()));
			projects = projects.Where(p => p.StartDate == filterDto.StartDate);
			projects = projects.Where(p => p.EndDate == filterDto.EndDate);
			projects = projects.Where(p => p.Status == filterDto.Status);
			projects = projects.Where(p => p.Priority == filterDto.Priority);

			var data = projects.OrderBy(p => p.Priority).Select(p => new ProjectDto
			{
				Name = p.Name,
				Status = p.Status,
				StartDate = p.StartDate,
				EndDate = p.EndDate,
				Priority = p.Priority
			}).ToList();
			exec.Data = data;
			return exec;
			
		}
    }
}
