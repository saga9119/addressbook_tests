using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System;

namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupTest : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for(int i = 0;  i < 5; i++)
            {
                groups.Add(new GroupData() {
                    Name = GenerateRandomString(30),
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData() {
                    Name = parts[0],
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
 
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));   
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void CreateGroupWithoutParentTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Group.GetGroupsList();
            app.Group.CreateGroup(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupsCount());

            List<GroupData> newGroups = app.Group.GetGroupsList();
            newGroups.Sort();
            group.GroupId = newGroups.Find(g => (g.Name == group.Name)).GroupId;

            oldGroups.Add(group);
            oldGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void TestDBConnection()
        {
            //GroupData.GetAllFromDB().ForEach(p => System.Console.Out.WriteLine(p));

            System.Console.Out.WriteLine("lol");

            foreach (ContactData contact in GroupData.GetAllFromDB()[0].GetContacts())
            {
                
                System.Console.Out.WriteLine(contact.Deprecated);
            }
        }

    }
}
