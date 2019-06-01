using RepoLab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.ViewModels
{
    public class TaskPostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ClosedAt { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string TaskImportance { get; set; }

        public List<Comment> Comments { get; set; }

        public static Taskul ToTaskul(TaskPostModel task)
        {
            Status taskStatus = Models.Status.Open;
            if (task.Status == "InProgress")
            {
                taskStatus = Models.Status.InProgress;
            }
            else if (task.Status == "Closed")
            {
                taskStatus = Models.Status.Closed;
            }
            TaskImportance taskImportance = Models.TaskImportance.Low;
            if (task.TaskImportance == "Medium")
            {
                taskImportance = Models.TaskImportance.Medium;
            }
            else if (task.TaskImportance == "High")
            {
                taskImportance = Models.TaskImportance.High;
            }
            return new Taskul
            {
                Title = task.Title,
                Description = task.Description,
                DateAdded = task.DateAdded,
                Deadline = task.Deadline,
                ClosedAt = task.ClosedAt,
                Status = taskStatus,
                TaskImportance = taskImportance,
                Comments = task.Comments
            };
        }
    }
}
