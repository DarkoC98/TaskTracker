using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerTests
{
    public static class Helper
    {
        public static TaskTrackerContext GetFakeMemoryDB()
        {
            var options = new DbContextOptionsBuilder<TaskTrackerContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            return new TaskTrackerContext(options);
                
        }
    }
}
