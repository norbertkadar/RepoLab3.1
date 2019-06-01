using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLab3.Models.DataContext
{
    public static class TaskuriDbSeeder
    {
        public static void Initialize(TaskuriDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Tasks.
            if (context.Taskuri.Any())
            {
                return;   // DB has been seeded
            }
            
            context.Taskuri.AddRange(
                new Taskul
                {
                    Title = "update console app",
                    Description = "update",
                    DateAdded = new DateTime(2019, 09, 12, 12, 34, 00),
                    Deadline = new DateTime(2019, 12, 22, 11, 21, 22),
                    ClosedAt = null
                },
                new Taskul
                {
                    Title = "do something",
                    Description = "anything",
                    DateAdded = new DateTime(2018, 07, 22, 21, 44, 00),
                    Deadline = new DateTime(2019, 12, 22, 22, 21, 22),
                    ClosedAt = null
                }
            );
            context.SaveChanges(); // commit transaction
        }
    }
}
