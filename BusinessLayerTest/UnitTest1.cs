using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using BusinessLayerTests1;

namespace BusinessLayer.Implementations.Tests
{
    [TestClass()]
    public class DeleteUserLINQTests
    {
        // https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices


        private OurContext context = Helper.GetFakeMemoryDB();
        private DeleteUserLINQ deleteRequest = new DeleteUserLINQ();

        [TestMethod()]
        public void Delete_User_DeletesUser()
        {
            // ============= PRIPREMA PODATAKA ZA TESTIRANJE (DEO 1)
            // **** ARANGE ******
            User userForInsert = new User
            {
                Id = 1,
                Username = "Username"
            };
            User expectedFromDB = null;
            context.users.Add(userForInsert);
            context.SaveChanges();


            // ============= IZVRASAVANJE METODE KOJA SE TESTIRA (DEO 2)
            // **** ACT ******
            deleteRequest.Execute(context, 1);

            // ============= PROVERA -> DA LI JE STANJE KAO OCEKIVANO (DEO 3)
            // ******** ASSERT *******
            var deletedUserFromDB = context.users.Where(u => u.Id == 1).FirstOrDefault();
            Assert.AreEqual(deletedUserFromDB, expectedFromDB);


        }


        [TestMethod()]
        [ExpectedException(typeof(Exception), "ASD")]
        public void Delete_User_ThrowsException()
        {
            this.deleteRequest.Execute(context, -2);
        }
    }
}