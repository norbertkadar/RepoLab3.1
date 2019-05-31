using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepoLab3.Models;
using RepoLab3.Models.DataContext;

namespace RepoLab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskuriController : ControllerBase
    {
        private TaskuriDbContext context;
        public TaskuriController(TaskuriDbContext context)
        {
            this.context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Taskul> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            IQueryable<Taskul> result = context.Taskuri.Include(c => c.Comments);
            if (from == null && to == null)
            {
                return result;
            }
            if (from != null)
            {
                result = result.Where(p => p.Deadline >= from);
            }
            if (to != null)
            {
                result = result.Where(p => p.Deadline <= to);
            }
            return result;

        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            var existing = context.Taskuri
                .Include(c => c.Comments)
                .FirstOrDefault(t => t.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        //POST: api/Tasks
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] Taskul task)
        {
            if (ModelState.IsValid)
            {
                context.Taskuri.Add(task);
                context.SaveChanges();
            }
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] Taskul task)
        {
            var exists = context.Taskuri.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (exists == null)
            {
                context.Taskuri.Add(task);
                context.SaveChanges();
                return Ok(task);
            }

            if (task.StatusId.Equals(3))
            {
                DateTime localDate = DateTime.Now;
                task.ClosedAt = localDate;
            }
            else
            {
                task.ClosedAt = DateTime.MaxValue;
            }

            context.Taskuri.Update(task);
            context.SaveChanges();
            return Ok(task);
        }

        //Delete: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var exists = context.Taskuri.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (exists == null)
            {
                return NotFound();
            }
            context.Taskuri.Remove(exists);
            context.SaveChanges();
            return Ok();
        }
    }
}