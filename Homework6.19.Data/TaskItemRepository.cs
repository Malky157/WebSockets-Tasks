using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._19.Data
{
    public class TaskItemRepository
    {
        public readonly string _connectionString;
        public TaskItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TaskItem Add(TaskItem task)
        {
            var context = new TaskItemDbContext(_connectionString);
            context.TaskItems.Add(task);
            context.SaveChanges();
            return task;
        }

        public List<TaskItem> GetAll()
        {
            var context = new TaskItemDbContext(_connectionString);
            return context.TaskItems.ToList();
        }

        public void UpdateTaskItem(TaskItem task)
        {
            var context = new TaskItemDbContext(_connectionString);
            var t = context.TaskItems.FirstOrDefault(t => t.Id == task.Id);
            if (t != null)
            {
                t.UserIdStarted = task.UserIdStarted;
                context.TaskItems.Attach(t);
                context.Update(t);
                context.SaveChanges();
            }
        }

        public void DeleteTaskItem(TaskItem task)
        {
            var context = new TaskItemDbContext(_connectionString);
            var taskToDelete = context.TaskItems.FirstOrDefault(t => t.Id == task.Id);
            if (taskToDelete != null)
            {
                context.TaskItems.Remove(taskToDelete);
                context.SaveChanges();
            }
        }
    }
}
