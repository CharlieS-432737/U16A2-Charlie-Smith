using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_server_app.models
{
    public class TaskModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}