using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
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


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContactWithoutGroupTestTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contact.GetContactsList();
            app.Contact.CreateContact(contact);

            app.Nav.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());
            List<ContactData> newContacts = app.Contact.GetContactsList();
            newContacts.Sort();
            contact.ContactId = newContacts.Find(c => (c.Lastname == contact.Lastname)).ContactId;
            oldContacts.Add(contact);
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
