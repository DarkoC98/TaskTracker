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
			if (!string.IsNullOrEmpty(taskFilterDto.Name))
			{
				tasks = tasks.Where(t => t.Name.ToLower().Contains(taskFilterDto.Name.ToLower()));


			}
			else
			{
				exec.Error.Add("Name cant be empty");
				return exec;

			}
			if (taskFilterDto.Description != null)
			{
				tasks = tasks.Where(t => t.Description == taskFilterDto.Description);
			}
			else
			{
				exec.Error.Add("Description cant be empty");
				return exec;

			}
			if (taskFilterDto.Priority != null  )
			{
				tasks = tasks.Where(t => t.Priority == taskFilterDto.Priority);

			}
			else
			{
				exec.Error.Add("Priority cant be empty");
				return exec;

			}
			if (taskFilterDto.Status != null)
			{
				tasks = tasks.Where(t => t.Status == taskFilterDto.Status);
			}
			else
			{
				exec.Error.Add("Status cant be empty");
				return exec;

			}

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
