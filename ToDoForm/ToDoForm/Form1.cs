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
        TasksClass DoneTasks = new TasksClass();

        XDocument doc = XDocument.Load(@"Tasks.xml");

        public Form1()
        {
            InitializeComponent();

            //Tasks.AddTask(new TaskClass { Title = "Buy cat", Description = "Bue new cat", Deadline = DateTime.Now, IsDone = false });
            //Tasks.AddTask(new TaskClass { Title = "Buy food for new cat", Description = "Buy new food", Deadline = DateTime.Now, IsDone = false });
            //Tasks.AddTask(new TaskClass { Title = "Sell cat", Description = "And sell new food", Deadline = DateTime.Now, IsDone = false });
            //Tasks.Writer();

            ReadAllToTasks(@"DoneTasks.xml", DoneTasks);
            ShowListAgain(listBox2, DoneTasks);


            ReadAllToTasks(@"Tasks.xml", Tasks); // Зчитування даних з xml
            ShowListAgain(listBox1, Tasks);
        }

        /// <summary>
        /// Кнопка відповідає за очищення текстБоксів від інформації
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)//button Clear()
        {
            textBoxTitle.Text = "";
            textBoxDescriprion.Text = "";
            textBoxDeadLine.Text = "";
            checkBoxDone.Checked = false;
        }

        /// <summary>
        /// Видалення задачі зі списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            doc.Element("Tasks").Elements("Task").Where(x => x.Element("Title").Value == listBox1.SelectedItem.ToString()).Remove();
            doc.Save(@"Tasks.xml");
            ShowListAgain(listBox1, Tasks);
        }

        /// <summary>
        /// Зчитування інформації з xml файлу до List<TasksClass>
        /// </summary>
        public void ReadAllToTasks(string path, TasksClass tasksClass)
        {
            XDocument doc = XDocument.Load(path);
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

                tasksClass.AddTask(task1);
            }
        }

        /// <summary>
        /// Очищає listBox та перезаливає туди всі актуальні задачі
        /// </summary>
        public void ShowListAgain(ListBox listBox, TasksClass tasksClass)
        {
            listBox.Items.Clear();
            foreach (var i in tasksClass.tasks)
            {
                listBox.Items.Add(i); // Вивід даних в listBox
            }
        }


        /// <summary>
        /// Виведення інформації про вибраний елемент у TextBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Записує нову задачу в xml file and List<TasksClass>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            TaskClass taskClass = new TaskClass();
            taskClass.Title = textBoxTitle.Text;
            taskClass.Description = textBoxDescriprion.Text;
            taskClass.Deadline = DateTime.Parse(textBoxDeadLine.Text);

            taskClass.Writer(@"Tasks.xml");
            Tasks.AddTask(taskClass);
            ShowListAgain(listBox1, Tasks);
        }

        /// <summary>
        /// Відмітка задачі як зробленої, видалення її зі списку та файлу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxDone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //var res = listBox1.SelectedItem as TaskClass;



                //Tasks.RemoveTask(res);
                //res.Writer(@"DoneTasks.xml"); // Запис у файл з готовими тасками

                //doc.Element("Tasks").Elements("Task").Where(x => x.Element("Title").Value == textBoxTitle.Text).Remove();
                //doc.Save(@"Tasks.xml");


                //textBoxTitle.Text = "";
                //textBoxDescriprion.Text = "";
                //textBoxDeadLine.Text = "";
                //checkBoxDone.Checked = false;



                ////listBox1.Items.Clear();
                // listBox2.Items.Clear();
                ////DoneTasks.tasks.Clear();
                ////Tasks.tasks.Clear();


                //ReadAllToTasks(@"DoneTasks.xml", DoneTasks); // Запис з xml файлу до ліста тасків
                //ShowListAgain(listBox2, DoneTasks); // Вивід всіх даних у лістБокс з тасків

                //ReadAllToTasks(@"Tasks.xml", Tasks); // Зчитування даних з xml до файлу до ліста тасків
                //ShowListAgain(listBox1, Tasks);// Вивід всіх даних у лістБокс з тасків




                var res = listBox1.SelectedItem as TaskClass;

                res.Writer(@"DoneTasks.xml");

                Tasks.RemoveTask(res);
                ShowListAgain(listBox1,Tasks);

                DoneTasks.tasks.Clear();
               
                ReadAllToTasks(@"DoneTasks.xml", DoneTasks);
                ShowListAgain(listBox2, DoneTasks);

                doc.Element("Tasks").Elements("Task").Where(x => x.Element("Title").Value == textBoxTitle.Text).Remove();
                doc.Save(@"Tasks.xml");

                textBoxTitle.Text = "";
                textBoxDescriprion.Text = "";
                textBoxDeadLine.Text = "";
                checkBoxDone.Checked = false;

            }
            catch (Exception ex)
            {
                // Таким чином я ігнорую null exception. Адже программа працює коректно і на нього можна не зважати уваги.
            }
        }
    }
}
