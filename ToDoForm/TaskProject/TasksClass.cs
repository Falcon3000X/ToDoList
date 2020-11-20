using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{

    public class TasksClass
    {
        public List<TaskClass> tasks = new List<TaskClass>();


        public void AddTask(TaskClass task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(TaskClass task)
        {
            tasks.Remove(task);
        }


        public void Writer()
        {
            foreach (var task in tasks)
                task.Writer(@"Tasks.xml");
        }

    }
}
