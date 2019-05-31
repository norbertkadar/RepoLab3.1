using Microsoft.EntityFrameworkCore;
using RepoLab3.Models;
using RepoLab3.Models.DataContext;
using RepoLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskGetModel> GetAll(DateTime? from = null, DateTime? to = null);
        Taskul GetById(int id);
        Taskul Create(TaskPostModel task);
        Taskul Upsert(int id, Taskul task);
        Taskul Delete(int id);
    }

    public class TaskService : ITaskService
    {
        private TaskuriDbContext context;
        public TaskService(TaskuriDbContext context)
        {
            this.context = context;
        }

        public Taskul Create(TaskPostModel taskPost)
        {
            Taskul toAdd = TaskPostModel.ToTaskul(taskPost);
            context.Taskuri.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Taskul Delete(int id)
        {
            var existing = context.Taskuri.FirstOrDefault(task => task.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Taskuri.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public IEnumerable<TaskGetModel> GetAll(DateTime? from = null, DateTime? to = null)
        {
            IQueryable<Taskul> result = context
                .Taskuri
                .Include(f => f.Comments);
            if (from == null && to == null)
            {
                return result.Select(t => TaskGetModel.FromTask(t));
            }
            if (from != null)
            {
                result = result.Where(t => t.Deadline >= from);
            }
            if (to != null)
            {
                result = result.Where(t => t.Deadline <= to);
            }
            return result.Select(t => TaskGetModel.FromTask(t));
        }

        public Taskul GetById(int id)
        {
            // sau context.Flowers.Find()
            return context.Taskuri
                .Include(t => t.Comments)
                .FirstOrDefault(t => t.Id == id);
        }

        public Taskul Upsert(int id, Taskul task)
        {
            var existing = context.Taskuri.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (existing == null)
            {
                context.Taskuri.Add(task);
                context.SaveChanges();
                return task;
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
            task.Id = id;
            context.Taskuri.Update(task);
            context.SaveChanges();
            return task;
        }
    }


   
}
