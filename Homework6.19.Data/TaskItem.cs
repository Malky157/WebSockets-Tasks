using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Homework6._19.Data
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }       
        
        public int? UserIdStarted { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
