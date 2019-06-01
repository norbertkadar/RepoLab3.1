using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.Models
{
    public enum Status
    {
        Open = 1,
        InProgress = 2,
        Closed = 3
    }

    public enum TaskImportance
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
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
        public DateTime? ClosedAt { get; set; }

        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        [EnumDataType(typeof(TaskImportance))]
        public TaskImportance TaskImportance { get; set; }


        public List<Comment> Comments { get; set; }
    }
}
