using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    [TestFixture]
    class TestClassForTasksClass
    {

        [Test]
        public void AddNewElementToTasks()
        {
            TaskClass task = new TaskClass();
            TasksClass tasksClass = new TasksClass();

            tasksClass.AddTask(task);
        }

        [Test]
        public void RemoveTaskFromTasks()
        {
            TaskClass task = new TaskClass();
            TasksClass tasksClass = new TasksClass();

            tasksClass.AddTask(task);

            tasksClass.RemoveTask(task);
        }


    }
}
