using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using TaskProject;

namespace ToDoForm
{
    public partial class Form1 : Form
    {
        TasksClass Tasks = new TasksClass();
        XDocument doc = XDocument.Load(@"Tasks.xml");

        public Form1()
        {
            InitializeComponent();

            //Tasks.AddTask(new TaskClass { Title = "Buy cat", Description = "Bue new cat", Deadline = DateTime.Now, IsDone = false });
            //Tasks.AddTask(new TaskClass { Title = "Buy food for new cat", Description = "Buy new food", Deadline = DateTime.Now, IsDone = false });
            //Tasks.AddTask(new TaskClass { Title = "Sell cat", Description = "And sell new food", Deadline = DateTime.Now, IsDone = false });
            //Tasks.Writer();

            ReadAllToTasks(); // Зчитування даних з xml

            ShowListAgain();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = "";
            textBoxDescriprion.Text = "";
            textBoxDeadLine.Text = "";
            checkBoxDone.Checked = false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            doc.Element("Tasks").Elements("Task").Where(x => x.Element("Title").Value == listBox1.SelectedItem.ToString()).Remove();
            doc.Save(@"Tasks.xml");
            ShowListAgain();
        }

        public void ReadAllToTasks()
        {
            XDocument doc = XDocument.Load(@"Tasks.xml");
            var tasks = doc.Element("Tasks").Elements().Select(x => new
            {
                Title = x.Element("Title").Value,
                Description = x.Element("Description").Value,
                Deadline = x.Element("Deadline").Value,
                IsDone = x.Element("IsDone").Value
            }).ToList();


            foreach (var task in tasks)
            {
                TaskClass task1 = new TaskClass();
                task1.Title = task.Title;
                task1.Description = task.Description;
                task1.Deadline = DateTime.Parse(task.Deadline);
                task1.IsDone = bool.Parse(task.IsDone);

                Tasks.AddTask(task1);
            }
        }

        public void ShowListAgain()
        {
            listBox1.Items.Clear();
            foreach (var i in Tasks.tasks)
            {
                listBox1.Items.Add(i); // Вивід даних в listBox
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var i in Tasks.tasks)
                {
                    if (i.Title == listBox1.SelectedItem.ToString())
                    {

                        textBoxTitle.Text = i.Title;
                        textBoxDescriprion.Text = i.Description;
                        textBoxDeadLine.Text = i.Deadline.ToString();

                        if (i.IsDone)
                            checkBoxDone.Checked = true;
                        else
                            checkBoxDone.Checked = false;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TaskClass taskClass = new TaskClass();
            taskClass.Title = textBoxTitle.Text;
            taskClass.Description = textBoxDescriprion.Text;
            taskClass.Deadline = DateTime.Parse(textBoxDeadLine.Text);

            taskClass.Writer(@"Tasks.xml");
            Tasks.AddTask(taskClass);
            ShowListAgain();
        }
    }
}
