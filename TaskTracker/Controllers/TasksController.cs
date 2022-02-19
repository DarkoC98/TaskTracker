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


        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IGetTaskById getTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = getTask.getTaskById(context, id);
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

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskDto taskDto,
            [FromServices] ICreateTask createTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = createTask.CreateTask(context, taskDto);
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

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] PutTaskDto dto,
            [FromServices] IPutTask putTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = putTask.PutTasks(context, dto, id);
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

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteTask deleteTask,
            [FromServices] TaskTrackerContext context)
        {
            var returns = deleteTask.Execute(context, id);
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
    }
}
