using Business.Implementations;
using Business.Interface;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Adding DI AddTransient
            services.AddTransient<IGetTaskById, GetTaskById>();
            services.AddTransient<IGetProjectById, GetProjectById>();
            services.AddTransient<IGetAllProjects, GetAllProjects>();
            services.AddTransient<IGetTask, GetTask>();
            services.AddTransient<ICreateTask, CreateTasks>();
            services.AddTransient<ICreateProject, CreateProject>();
            services.AddTransient<IDeleteTask, DeleteTask>();
            services.AddTransient<IDeleteProject, DeleteProject>();
            services.AddTransient<IPutTask, PutTask>();
            services.AddTransient<IPutProject, PutProject>();

            services.AddDbContext<TaskTrackerContext>(options =>
            {
                options.EnableSensitiveDataLogging(true).LogTo(Console.WriteLine);
                options.UseSqlServer(
                    "Integrated Security=SSPI;Initial Catalog=TaskTracker;Data Source=DESKTOP-OF71O4M\\SQLEXPRESS;",
                    b => b.MigrationsAssembly("DataAccess"));
            }).AddLogging();
 

             services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskTracker", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskTracker v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
