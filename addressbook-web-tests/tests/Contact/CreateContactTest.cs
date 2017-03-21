using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {

        [Test]
        public void CreateContactWithoutGroupTestTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactsList();
            ContactData contact = new ContactData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            contact.Lastname = "lastname" + timestamp;
            contact.Firstname = "firstname" + timestamp;
            app.Contact.CreateContact(contact);
            app.Nav.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());
            List<ContactData> newContacts = app.Contact.GetContactsList();
            newContacts.Sort();
            contact.ContactId = newContacts[newContacts.Count - 1].ContactId;
            oldContacts.Add(contact);
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
