using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class TaskClass
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }

        public TaskClass() { }
        public TaskClass(int id, string title, string desc, DateTime dateTime)
        {
            this.TaskID = id;
            this.Title = title;
            this.Description = desc;
            this.Deadline = dateTime;
        }
    }
}
