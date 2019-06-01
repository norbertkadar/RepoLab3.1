using RepoLab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.ViewModels
{
    public class TaskGetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? ClosedAt { get; set; }
        public Status Status { get; set; }
        public TaskImportance TaskImportance { get; set; }
        public int NumberOfComments { get; set; }

        public static TaskGetModel FromTask(Taskul task)
        {
            Status taskStatus = Models.Status.Open;
            if (task.Status.ToString() == "InProgress")
            {
                taskStatus = Models.Status.InProgress;
            }
            else if (task.Status.ToString() == "Closed")
            {
                taskStatus = Models.Status.Closed;
            }
            TaskImportance taskImportance = Models.TaskImportance.Low;
            if (task.TaskImportance.ToString() == "Medium")
            {
                taskImportance = Models.TaskImportance.Medium;
            }
            else if (task.TaskImportance.ToString() == "High")
            {
                taskImportance = Models.TaskImportance.High;
            }
            return new TaskGetModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DateAdded = task.DateAdded,
                Deadline = task.Deadline,
                ClosedAt = task.ClosedAt,
                Status = taskStatus,
                TaskImportance = taskImportance,
                NumberOfComments = task.Comments.Count
            };
        }
    }
}
