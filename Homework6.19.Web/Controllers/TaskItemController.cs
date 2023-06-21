using Homework6._19.Data;
using Homework6._19.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Homework6._19.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly string _connectionString;
        private IHubContext<TaskItemHub> _hub;
        public TaskItemController(IConfiguration configuration, IHubContext<TaskItemHub> hub)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
            _hub = hub;
        }

        [HttpPost]
        [Route("addtaskitem")]
        public void AddTaskItem(TaskItem taskItem)
        {
            if (taskItem.Title != "" && taskItem != null)
            {
                var user = GetCurrentUser();
                taskItem.UserId = user.Id;
                var repo = new TaskItemRepository(_connectionString);
                repo.Add(taskItem);
                _hub.Clients.All.SendAsync("newTask", GetTaskItems());
            }
        }

        [HttpPost]
        [Route("updatestatus")]
        public void UpdateStatus(UpdateViewModel vm)
        {
            var repo = new TaskItemRepository(_connectionString);
            var user = GetCurrentUser();

            if (vm != null)
            {
                if (vm.Status == "in progress by me" && user.Id == vm.Item.UserIdStarted)
                {
                    repo.DeleteTaskItem(vm.Item);
                }
                else if (vm.Status == "not taken")
                {
                    vm.Item.UserIdStarted = user.Id;
                    repo.UpdateTaskItem(vm.Item);
                }
                else
                {
                    return;
                }
            }
            _hub.Clients.All.SendAsync("updatedTask", GetTaskItems());
        }


        [HttpGet]
        [Route("gettaskitems")]
        public List<TaskItem> GetTaskItems()
        {
            var repo = new TaskItemRepository(_connectionString);
            return repo.GetAll();
        }

        private User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var ur = new UserRepository(_connectionString);
            return ur.GetByEmail(User.Identity.Name);
        }
    }
}
