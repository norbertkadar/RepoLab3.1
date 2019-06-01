using RepoLab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.ViewModels
{
    public class CommentGetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public int? TaskulId { get; set; }

        public static CommentGetModel FromComment(Comment c)
        {
            return new CommentGetModel
            {
                Id = c.Id,
                Important = c.Important,
                Text = c.Text,
                TaskulId = c.Taskul?.Id,
            };
        }
    }
}
