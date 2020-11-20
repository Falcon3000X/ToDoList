using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    class Tasks
    {
        public List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            if (task != null)
                tasks.Add(task);
            else throw new Exception("Task was null!");
        }

        public void RemoveTask(Task task)
        {
            if (task != null)
                tasks.Remove(task);
            else throw new Exception("Tasw was null!");
        }

        public void Writer()
        {
            foreach (var task in tasks)
                task.Writer(@"Tasks.xml");
        }

    }
}
