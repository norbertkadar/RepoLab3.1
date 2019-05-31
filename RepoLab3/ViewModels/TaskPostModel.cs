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
        public DateTime ClosedAt { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int TaskImportanceId { get; set; }

        public static Taskul ToTaskul(TaskPostModel task)
        {

            return new Taskul
            {
                Title = task.Title,
                Description = task.Description,
                DateAdded = task.DateAdded,
                Deadline = task.Deadline,
                ClosedAt = task.ClosedAt,
                StatusId = task.StatusId,
                TaskImportanceId = task.TaskImportanceId
            };
        }
    }
}
