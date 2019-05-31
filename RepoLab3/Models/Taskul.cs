using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.Models
{
    public class Taskul
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ClosedAt { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Required]
        [ForeignKey("TaskImportance")]
        public int TaskImportanceId { get; set; }

        //[Display(Name = "Task Status")]
        //public virtual Status Status { get; set; }

        //[Display(Name = "Task Importance")]
        //public virtual TaskImportance TaskImportance { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
