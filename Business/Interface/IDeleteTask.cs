using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDeleteTask
    {
        public void Execute(TaskTrackerContext context, int id);
    }
}
