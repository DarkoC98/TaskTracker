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
    public class GetTask : IGetTask
    {
        public ExecutionResult getTasks(TaskTrackerContext context, TaskFilterDto taskFilterDto)
        {
			ExecutionResult exec = new ExecutionResult();
			var tasks = context.tasks.AsQueryable();
			tasks = tasks.Where(t => t.Name.ToLower().Contains(taskFilterDto.Name.ToLower()));
			tasks = tasks.Where(t => t.Description == taskFilterDto.Description);
			tasks = tasks.Where(t => t.Priority == taskFilterDto.Priority);
			tasks = tasks.Where(t => t.Status == taskFilterDto.Status);

			var data = tasks.OrderBy(t => t.Priority).Select(t => new TaskDto
			{
				Name = t.Name,
				Description = t.Description,
				Priority = t.Priority,
				Status = t.Status,
				ProjectName = t.Project.Name,
				ProjectId = t.ProjectId
			}).ToList();

			exec.Data = data;
			return exec;
		}
    }
}
