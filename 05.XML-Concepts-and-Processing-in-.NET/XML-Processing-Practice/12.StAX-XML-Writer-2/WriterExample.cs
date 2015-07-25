using System;
using System.Text;
using System.Xml;

namespace _12.StAX_XML_Writer_2
{
    class WriterExample
    {
        static void Main()
        {
            string fileName = "../../students.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("students");
                writer.WriteAttributeString("name", "Students information");

                WriteStudent(writer, "Petar Petrov", "male", "1986-07-24");
                WriteStudent(writer, "Milena Ivanova", "female", "1988-01-16");
                WriteStudent(writer, "Stamat Stamatov", "male", "1962-07-01");

                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created.", fileName);
        }

        private static void WriteStudent(XmlTextWriter writer, string name, string gender, string birthDate)
        {
            writer.WriteStartElement("student");
            writer.WriteElementString("name", name);
            writer.WriteElementString("gender", gender);
            writer.WriteElementString("birth-date", birthDate);
            writer.WriteEndElement();
        }
    }
}
