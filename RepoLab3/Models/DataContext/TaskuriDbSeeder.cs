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
            context.Statuses.AddRange(
                new Status
                {
                    Name = "Open",
                },
                new Status
                {
                    Name = "In Progress",
                },
                new Status
                {
                    Name = "Closed"
                });
            context.SaveChanges();

            context.TasksImportance.AddRange(
                new TaskImportance
                {
                    Name = "Low"
                },
                new TaskImportance
                {
                    Name = "Medium"
                },
                new TaskImportance
                {
                    Name = "High"
                });
            context.SaveChanges();

            context.Taskuri.AddRange(
                new Taskul
                {
                    Title = "update console app",
                    Description = "update",
                    DateAdded = new DateTime(2019, 09, 12, 12, 34, 00),
                    Deadline = new DateTime(2019, 12, 22, 11, 21, 22),
                    ClosedAt = DateTime.MaxValue,
                    TaskImportanceId = 1,
                    StatusId = 1,
                },
                new Taskul
                {
                    Title = "do something",
                    Description = "anything",
                    DateAdded = new DateTime(2018, 07, 22, 21, 44, 00),
                    Deadline = new DateTime(2019, 12, 22, 22, 21, 22),
                    ClosedAt = DateTime.MaxValue,
                    TaskImportanceId = 3,
                    StatusId = 2,
                }
            );
            context.SaveChanges(); // commit transaction
        }
    }
}
