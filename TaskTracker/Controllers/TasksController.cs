using Business.DTO;
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
    public class TasksController : ControllerBase
    {
        // GET: api/<TasksController>
        [HttpGet]
        public IActionResult Get([FromQuery] TaskFilterDto taskFilterDto,
            [FromServices] IGetTask getTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = getTask.getTasks(context, taskFilterDto );

            try
            {
                if (!returns.IsSuccessful)
                {
                    return BadRequest(returns.Error);
                }
                else
                {
                    return Ok(returns.Data);

                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IGetTaskById getTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = getTask.getTaskById(context, id);

            try
            {
                if (!returns.IsSuccessful)
                {
                    return BadRequest(returns.Error);
                }
                else
                {
                    return Ok(returns.Data);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskDto taskDto,
            [FromServices] ICreateTask createTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = createTask.CreateTask(context, taskDto);

            try
            {
                if (!returns.IsSuccessful)
                {
                    return BadRequest(returns.Error);
                }
                else
                {
                    return Ok(returns.Message);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] PutTaskDto dto,
            [FromServices] IPutTask putTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = putTask.PutTasks(context, dto, id);
            try
            {
                if (!returns.IsSuccessful)
                {
                    return BadRequest(returns.Error);
                }
                else
                {
                    return Ok(returns.Message);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteTask deleteTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = deleteTask.Execute(context, id);
            try
            {
                if (!returns.IsSuccessful)
                {
                    return BadRequest(returns.Error);
                }
                else
                {
                    return Ok(returns.Message);

                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }
    }
}
