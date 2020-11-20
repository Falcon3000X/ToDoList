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
using TaskProject;

namespace ToDoForm
{
    public partial class Form1 : Form
    {
        TasksClass Tasks = new TasksClass();

        public Form1()
        {
            InitializeComponent();

            ReadAll();

            foreach (var i in Tasks.tasks)
            {
                listBox1.Items.Add(i);
            }




        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

        }

        public void ReadAll()
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
    }
}
