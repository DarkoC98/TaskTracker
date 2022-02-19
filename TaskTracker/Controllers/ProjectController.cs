using Business.DTO;
using Business.Execution;
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
            var returns = getAll.getAllProjects(context, filterDto);

            var result = returns.Data;
            var error = returns.Error;
            var success = returns.IsSuccessful; 
            
            try
            {
                if (!success)
                {
                    return BadRequest(error);
                }
                else
                {
                    return Ok(result);
                    
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, 
            [FromServices] TaskTrackerContext context,
            [FromServices] IGetProjectById getProject)
        {
            var returns = getProject.getProjectsById(context, id);
            var result = returns.Data;
            var error = returns.Error;
            var success = returns.IsSuccessful;
            try
            {
                if (!success)
                {
                    return BadRequest(error);
                }
                else
                {
                    return Ok(result);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDto projectDto,
            [FromServices] ICreateProject createProject,
            [FromServices] TaskTrackerContext context)
        {
            var returns = createProject.CreateProjects(context, projectDto);
            var result = returns.Data;
            var message = returns.Message;
            var error = returns.Error;
            var success = returns.IsSuccessful; 
            try
            {
                if (!success)
                {
                    return BadRequest(error);
                }
                else
                {
                    return Ok(message);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,
            [FromBody] ProjectDto dto,
            [FromServices] IPutProject putProject,
            [FromServices] TaskTrackerContext context)
        {

            var returns = putProject.PutProjects(context, dto, id);
            var result = returns.Data;
            var message = returns.Message;
            var error = returns.Error;
            var success = returns.IsSuccessful;
            try
            {
                if (!success)
                {
                    return BadRequest(error);
                }
                else
                {
                    return Ok(message);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteProject deleteProject,
            [FromServices] TaskTrackerContext context)
        {
            var returns = deleteProject.Execute(context, id);
            var result = returns.Data;
            var message = returns.Message;
            var error = returns.Error;
            var success = returns.IsSuccessful;
            try
            {
                if (!success)
                {
                    return BadRequest(error);
                }
                else
                {
                    return Ok(message);
                    
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{projectId}/Tasks")]
        public IActionResult GetAllProjectTasks(int projectId,
            [FromServices] TaskTrackerContext context,
            [FromServices] IGetAllTasksForOneProject getTasks)
        {

            var returns = getTasks.getAllTasksForProject(context, projectId);
            var result = returns.Data;
            var error = returns.Error;
            var success = returns.IsSuccessful;
            try
            {
                
                
                if (!success)
                {
                    return BadRequest(error);   
                }
                else
                {
                    return Ok(result);
                }
                
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
