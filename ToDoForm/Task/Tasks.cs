using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    [TestFixture]
    public class Tasks
    {
        public List<TaskClass> TasksList { get; set; }

        [Test]
        public void Add(TaskClass task)
        {
            TasksList.Add(task);
        }

        [Test]
        public void Remove(TaskClass task)
        {
            TasksList.Remove(task);
        }

        [Test]
        public List<TaskClass> GetAllTasks()
        {
            return TasksList;
        }

    }
}
