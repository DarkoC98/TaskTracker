using Business.DTO;
using Business.Interface;
using Business.Validation;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly TaskTrackerContext _context;
        // GET: api/<TasksController>
        [HttpGet]
        public IActionResult Get([FromQuery] TaskFilterDto taskFilterDto,
            [FromServices] IGetTask getTask,
            [FromServices] TaskTrackerContext context)
        {
            var validator = new GetAllTasksValidation(this._context);
            var result = validator.Validate(taskFilterDto);

            try
            {
                if (!result.IsValid)
                {
                    var errors = result.Errors.Select(err => new
                    {
                        PropertyName = err.PropertyName,
                        PropertyError = err.ErrorMessage
                    });
                    return BadRequest(errors);
                }
                var returns = getTask.getTasks(context, taskFilterDto);

                if (!returns.IsSuccessful)
                {
                    var errors = returns.Error.Select(err => new
                    {
                        ErrorMessage = err
                    });
                    return BadRequest(errors);
                }
                return Ok(returns.Data);

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
            
            var validator = new CreateTaskValidation(_context);
            var result = validator.Validate(taskDto);

            try
            {
                if (!result.IsValid)
                {
                    var errors = result.Errors.Select(err => new
                    {
                        PropertyName = err.PropertyName,
                        PropertyError = err.ErrorMessage
                    });
                    return BadRequest(errors);
                }
                var returns = createTask.CreateTask(context, taskDto);

                if (!returns.IsSuccessful)
                {
                    var errors = returns.Error.Select(err => new
                    {
                        ErrorMessage = err
                    });
                    return BadRequest(errors);
                }
                return Ok(returns.Message);

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
