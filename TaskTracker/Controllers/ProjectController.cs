using Business.DTO;
using Business.Implementations;
using Business.Interface;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // GET: api/<ProjectController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProjectFilterDto filterDto,
            [FromServices] IGetAllProjects getAll,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                var result = getAll.getAllProjects(context, filterDto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, 
            [FromServices] TaskTrackerContext context,
            [FromServices] IGetProjectById getProject)
        {
            try
            {
                return Ok(getProject.getProjectsById(context, id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
                  
        }

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDto projectDto,
            [FromServices] ICreateProject createProject,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                createProject.CreateProjects(context, projectDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id,
            [FromBody] ProjectDto dto,
            [FromServices] IPutProject putProject,
            [FromServices] TaskTrackerContext context)
        {

            putProject.PutProjects(context, dto, id);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices] IDeleteProject deleteProject,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                deleteProject.Execute(context, id);
            }
            catch(Exception ex)
            {
                BadRequest(ex);
            }
        }
    }
}
