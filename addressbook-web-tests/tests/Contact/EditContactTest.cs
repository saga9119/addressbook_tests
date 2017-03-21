using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class EditContactTest : ContactTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            contact.Lastname = "lastname" + timestamp;
            contact.Firstname = "firstname" + timestamp;
            app.Nav.GoToContactsPage();

            List<ContactData> oldContacts = app.Contact.GetContactsList();
            app.Contact.EditContact(0, contact);
            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactsCount());

            List<ContactData> newContacts = app.Contact.GetContactsList();
            newContacts.Sort();
            contact.ContactId = newContacts[newContacts.Count - 1].ContactId;
            oldContacts[0] = contact;
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
