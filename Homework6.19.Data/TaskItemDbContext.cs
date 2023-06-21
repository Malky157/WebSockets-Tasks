using Homework6._19.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._19.Data
{
    public class TaskItemDbContext : DbContext
    {
        private string _connectionString;

        public TaskItemDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}

