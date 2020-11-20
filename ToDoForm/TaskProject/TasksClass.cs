using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    class TasksClass
    {
        public List<TaskClass> tasks = new List<TaskClass>();

        public void AddTask(TaskClass task)
        {
            if (task != null)
                tasks.Add(task);
            else throw new Exception("Task was null!");
        }

        public void RemoveTask(TaskClass task)
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
