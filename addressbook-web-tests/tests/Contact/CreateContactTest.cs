using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateContactTests : ContactTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                ContactData contact = new ContactData().AutoFill();
                contact.Firstname = GenerateRandomString(30);
                contact.Lastname = GenerateRandomString(30);
                contacts.Add(contact);
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void CreateContactWithoutGroupTestTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            app.Contact.CreateContact(contact);

            app.Nav.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());
            List<ContactData> newContacts = ContactData.GetAllFromDB();
            newContacts.Sort();
            contact.ContactId = newContacts.Find(c => (c.Lastname == contact.Lastname)).ContactId;
            oldContacts.Add(contact);
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
