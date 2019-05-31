using RepoLab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.ViewModels
{
    public class TaskGetModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ClosedAt { get; set; }
        public string Status { get; set; }
        public string TaskImportance { get; set; }
        public int NumberOfComments { get; set; }

        public static TaskGetModel FromTask(Taskul task)
        {
            return new TaskGetModel
            {
                Title = task.Title,
                Description = task.Description,
                DateAdded = task.DateAdded,
                Deadline = task.Deadline,
                ClosedAt = task.ClosedAt,
                Status = (task.StatusId.Equals(1)) ? "Open" : ((task.StatusId.Equals(2))? "In Progress":"Closed"),
                TaskImportance = (task.TaskImportanceId.Equals(1)) ? "Low" : ((task.TaskImportanceId.Equals(2)) ? "Medium" : "High"),
                NumberOfComments = task.Comments.Count
            };
        }
    }
}
