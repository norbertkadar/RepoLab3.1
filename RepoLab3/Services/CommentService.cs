using curs_2_webapi.ViewModels;
using Microsoft.EntityFrameworkCore;
using RepoLab3.Models;
using RepoLab3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentGetModel> GetAll(string filterString);
    }
    public class CommentService : ICommentService
    {
        private TaskuriDbContext context;
        public CommentService(TaskuriDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CommentGetModel> GetAll(string filterString)
        {
            IQueryable<Comment> result = context
                .Comments
                .Where(c => string.IsNullOrEmpty(filterString) || c.Text.Contains(filterString))
                .Include(c => c.Taskul);
 
            return result.Select(t => CommentGetModel.FromComment(t)).ToList(); ;
        }

    }
}
