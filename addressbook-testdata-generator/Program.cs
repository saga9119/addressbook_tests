using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using AddressbookWebTests;

namespace addressbook_testdata_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

     
            if (dataType == "group")
            {
                 List<GroupData> data = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    data.Add(new GroupData()
                    {
                        Name = TestBase.GenerateRandomString(10),
                        Header = TestBase.GenerateRandomString(30),
                        Footer = TestBase.GenerateRandomString(30)
                    });
                }

                if (format == "csv")
                {
                    writeGroupToCsvFile(data, writer);
                }
                else if (format == "xml")
                {
                    writeGroupToXmlFile(data, writer);
                }
                else if (format == "json")
                {
                    writeGroupToJsonFile(data, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else if (dataType == "contact")
            {
                List<ContactData> data = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {

                    data.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(30),
                        Address = TestBase.GenerateRandomString(30),
                        ContactId = "-1"
                    });
                }

                if (format == "csv")
                {
                    writeContactToCsvFile(data, writer);
                }
                else if (format == "xml")
                {
                    writeContactToXmlFile(data, writer);
                }
                else if (format == "json")
                {
                    writeContactToJsonFile(data, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

            }
            writer.Close();
        }



        static void writeGroupToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", 
                    group.Name, group.Header, group.Footer));
            }
        
        }

        static void writeGroupToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }


        static void writeContactToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contact.Firstname, contact.Lastname, contact.Nickname));
            }

        }

        static void writeContactToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
