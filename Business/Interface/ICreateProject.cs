using Business.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICreateProject
    {
        public void CreateProjects(TaskTrackerContext context, ProjectDto dto);
    }
}
