using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlFileApps
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Beginning
            XmlWriter xmlWriter = XmlWriter.Create("Test.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("users");

            xmlWriter.WriteStartElement("user");
            xmlWriter.WriteAttributeString("age", "42");
            xmlWriter.WriteString("John Doe");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("user");
            xmlWriter.WriteAttributeString("age", "21");
            xmlWriter.WriteString("Jane Doe");

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            #endregion

            #region Advanced
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 1,Name = "David Smith", Salary = 5000},
                new Employee(){Id = 2,Name = "Mark Drinkwater", Salary = 6000},
                new Employee(){Id = 3,Name = "Norah Miller", Salary = 8000}
            };

            using (XmlWriter writer = XmlWriter.Create("Employees.xml"))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("Employees");
                foreach (Employee employee in employees)
                {
                    writer.WriteStartElement("Employee");
                    writer.WriteElementString("Id", employee.Id.ToString());
                    writer.WriteElementString("Name", employee.Name);
                    writer.WriteElementString("Salary", employee.Salary.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
            #endregion


            #region ReadXmlFile
            XmlDocument aXmlDocument = new XmlDocument();
            aXmlDocument.Load("Employees.xml");
            aXmlDocument.Save(Console.Out);

            Console.WriteLine();

            XmlTextReader reader = new XmlTextReader("Employees.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Id")
                        {
                            Console.Write(reader.Name + "-");
                        }
                        if (reader.Name == "Name")
                        {
                            Console.Write(reader.Name + "-");
                        }
                        if (reader.Name == "Salary")
                        {
                            Console.Write(reader.Name + "-");
                        }
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value + "\n");
                        break;
                }
            }
            #endregion

            Console.ReadLine();
        }
    }
}
