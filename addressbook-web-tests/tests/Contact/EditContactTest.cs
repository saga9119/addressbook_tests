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

            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            ContactData contact = new ContactData() {
                Lastname = "lastname" + timestamp,
                Firstname = "firstname" + timestamp
        };
            app.Nav.GoToContactsPage();

            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            app.Contact.EditContact(0, contact);
            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllFromDB();
            newContacts.Sort();
            contact.ContactId = newContacts.Find(c => (c.Lastname == contact.Lastname)).ContactId;
            oldContacts[0] = contact;
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
