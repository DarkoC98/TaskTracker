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
    public class GetTask : IGetTask
    {
        public IQueryable getTasks(TaskTrackerContext context, TaskFilterDto taskFilterDto)
        {
			var tasks = context.tasks.AsQueryable();
			if (!string.IsNullOrEmpty(taskFilterDto.Name))
			{
				tasks = tasks.Where(t => t.Name.ToLower().Contains(taskFilterDto.Name.ToLower()));


			}
			if (taskFilterDto.Description != null)
			{
				tasks = tasks.Where(t => t.Description == taskFilterDto.Description);
			}
			if (taskFilterDto.Priority != null  )
			{
				tasks = tasks.Where(t => t.Priority == taskFilterDto.Priority);

			}
			if (taskFilterDto.Status != null)
			{
				tasks = tasks.Where(t => t.Status == taskFilterDto.Status);
			}

			var data = tasks.OrderBy(t => t.Priority).Select(t => new TaskFilterDto
			{
				Name = t.Name,
				Description = t.Description,
				Priority = t.Priority,
				Status = t.Status
			}).ToList();
			return data.AsQueryable();
		}
    }
}
