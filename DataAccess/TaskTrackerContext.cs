using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class TaskTrackerContext : DbContext

    {
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Project> projects { get; set; }

        public TaskTrackerContext(DbContextOptions options) : base(options)
        { }
    }


}
