using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTracker.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessLayerTests;
using Business.Implementations;
using DataAccess.Entities;

namespace TaskTracker.Controllers.Tests
{
    [TestClass()]
    public class DeleteTaskTests
    {
        private TaskTrackerContext context = Helper.GetFakeMemoryDB();
        private DeleteTask deleteRequest = new DeleteTask();

        [TestMethod()]
        public void DeleteTest()
        {
            Tasks taskForInsert = new Tasks
            {
                Id = 1,
                Name = "Name",
                Status = TasksStatus.ToDo,
                Description = "Description",
                Priority = "Priority",
                ProjectId = 1,

            };
            Tasks expectedFromDB = null;
            context.tasks.Add(taskForInsert);
            context.SaveChanges();

            deleteRequest.Execute(context, 1);

            var deletedTaskFromDB = context.tasks.Where(t => t.Id == 1).FirstOrDefault();
            Assert.AreEqual(deletedTaskFromDB, expectedFromDB);
        }
    }
}