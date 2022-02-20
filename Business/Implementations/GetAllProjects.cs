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
            if(!string.IsNullOrEmpty(filterDto.Name))
            {
				projects = projects.Where(p => p.Name.ToLower().Contains(filterDto.Name.ToLower()));


            }
            else
            {
				exec.Error.Add("Name cant be empty");
				return exec;

			}
			if (filterDto.StartDate != null)
			{
				projects = projects.Where(p => p.StartDate == filterDto.StartDate);
			}
            else
            {
				exec.Error.Add("Start Date cant be empty");
				return exec;
			}
			if (filterDto.EndDate != null)
			{
				projects = projects.Where(p => p.EndDate == filterDto.EndDate);
				
			}
            else
            {
				exec.Error.Add("End Date cant be empty");
				return exec;
			}
			if (filterDto.Status >= 0 && Convert.ToInt32(filterDto.Status) <= 2)
			{
				projects = projects.Where(p => p.Status == filterDto.Status);
			}
            else
            {
				exec.Error.Add("Status has to be in range from 0 to 2");
				return exec;
			}
			if (filterDto.Priority != null)
			{
				projects = projects.Where(p => p.Priority == filterDto.Priority);
			}
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
