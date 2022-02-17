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
            try
            {
                var result = getTask.getTasks(context, taskFilterDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IGetTaskById query,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                var tasksForReturn = query.getTaskById(context, id);
                return Ok(tasksForReturn);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskDto taskDto,
            [FromServices] ICreateTask createTask,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                createTask.CreateTask(context, taskDto);
                return Ok();    
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, 
            [FromBody] PutTaskDto dto,
            [FromServices] IPutTask putTask,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                putTask.PutTasks(context, dto, id);
            }
            catch(Exception ex)
            {
                BadRequest(ex);
            }
            
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices] IDeleteTask deleteTask,
            [FromServices] TaskTrackerContext context)
        {
            try
            {
                
                deleteTask.Execute(context, id);
            } 
            catch(Exception ex)
            {
                //ispravi ovo
                BadRequest(ex);
            }
            
                
        }
    }
}
