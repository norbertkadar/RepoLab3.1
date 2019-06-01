using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.Models.DataContext
{
    public class TaskuriDbContext : DbContext
    {
        public TaskuriDbContext(DbContextOptions<TaskuriDbContext> options) : base(options)
        {
        }
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Taskul> Taskuri { get; set; }
    }
}
