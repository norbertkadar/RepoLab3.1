using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepoLab3.Models;
using RepoLab3.Models.DataContext;
using RepoLab3.Services;
using RepoLab3.ViewModels;

namespace RepoLab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskuriController : ControllerBase
    {
        private ITaskService taskService;
        public TaskuriController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<TaskGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return taskService.GetAll(from, to);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            var found = taskService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        /// <summary>
        /// Post Method
        /// </summary>
        /// 
        /// <param name="task"></param>
        //POST: api/Tasks
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] TaskPostModel task)
        {
            taskService.Create(task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] Taskul task)
        {

            var result = taskService.Upsert(id, task);
            
            return Ok(task);
        }

        //Delete: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var result = taskService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}