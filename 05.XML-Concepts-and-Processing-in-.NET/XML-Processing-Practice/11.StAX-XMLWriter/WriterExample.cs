using System;
using System.Text;
using System.Xml;

namespace _11.StAX_XMLWriter
{
    class WriterExample
    {
        static void Main()
        {
            string fileName = "../../books.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("library");
                writer.WriteAttributeString("name", "My library");
                WriteBook(writer, "Code Complete", "Steve McConnell", "125-252-696-4");
                WriteBook(writer, "Въведение в програмирането със C#", "Светлин Наков и колектив", "954-775-258-0");
                WriteBook(writer, "Writing Solid Code", "Steve McGuire", "343-345-123-4");
                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created.", fileName);
        }
        private static void WriteBook(XmlTextWriter writer, string title, string author, string isbn)
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("title", title);
            writer.WriteElementString("author", author);
            writer.WriteElementString("isbn", isbn);
            writer.WriteEndElement();
        }
    }
}