using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TaskProject
{
    public class TaskClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }

        public void Reader(XmlTextReader reader)
        {
            while (reader.Read())
            {

                    if (reader.NodeType == XmlNodeType.Element)
                    {

                        switch (reader.Name)
                        {
                            case "Title":
                                reader.Read();
                                this.Title = reader.Value;
                                break;

                            case "Description":
                                reader.Read();
                                this.Description = reader.Value;
                                break;

                            case "Deadline":
                                reader.Read();
                                this.Description = reader.Value;
                                break;

                            case "IsDone":
                                reader.Read();
                                this.IsDone = bool.Parse(reader.Value);
                                break;

                            default:
                                break;
                        }
                    }
                
            }
        }


        public void Writer(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = doc.DocumentElement;

            XmlNode task = doc.CreateElement("Task");

            XmlNode title = doc.CreateElement("Title");
            XmlNode titleText = doc.CreateTextNode(Title);

            XmlNode desc = doc.CreateElement("Description");
            XmlNode descText = doc.CreateTextNode(Description);

            XmlNode deadline = doc.CreateElement("Deadline");
            XmlNode deadlineText = doc.CreateTextNode(Deadline.ToString());

            XmlNode isDone = doc.CreateElement("IsDone");
            XmlNode isDoneValue = doc.CreateTextNode(IsDone.ToString());

            title.AppendChild(titleText);
            desc.AppendChild(descText);
            deadline.AppendChild(deadlineText);
            isDone.AppendChild(isDoneValue);

            task.AppendChild(title);
            task.AppendChild(desc);
            task.AppendChild(deadline);
            task.AppendChild(isDone);

            root.AppendChild(task);

            doc.Save(path);
        }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
