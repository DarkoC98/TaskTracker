using Business.Interface;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class DeleteProject : IDeleteProject
    {
        public void Execute(TaskTrackerContext context, int id)
        {
            var projectForDeletion = (from projects in context.projects
                                   where projects.Id == id
                                   select projects).FirstOrDefault();

            context.projects.Remove(projectForDeletion);
            context.SaveChanges();
        }
    }
}
