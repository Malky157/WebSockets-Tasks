using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Homework6._19.Data
{
    public class TaskItemDataContextFactory : IDesignTimeDbContextFactory<TaskItemDbContext>
    {
        public TaskItemDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Homework6.19.Web"))
               .AddJsonFile("appsettings.json")
               .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new TaskItemDbContext(config.GetConnectionString("ConStr"));
        }
    }
}

