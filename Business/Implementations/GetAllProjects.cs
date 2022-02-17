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
	public class GetAllProjects : IGetAllProjects
    {
		
        public IQueryable getAllProjects(TaskTrackerContext context, ProjectFilterDto filterDto)
        {
            var projects = context.projects.AsQueryable();
            if(!string.IsNullOrEmpty(filterDto.Name))
            {
				projects = projects.Where(p => p.Name.ToLower().Contains(filterDto.Name.ToLower()));


            }
			if (filterDto.StartDate != null)
			{
				projects = projects.Where(p => p.StartDate >= filterDto.StartDate);
			}
			if (filterDto.EndDate != null)
			{
				projects = projects.Where(p => p.EndDate <= filterDto.EndDate);
				
			}
			if (filterDto.Status != null)
			{
				projects = projects.Where(p => p.Status == filterDto.Status);
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
			return data.AsQueryable();
			
		}
    }
}
