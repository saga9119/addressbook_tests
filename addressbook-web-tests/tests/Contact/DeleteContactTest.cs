using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteContactTest : ContactTestBase
    {
        [Test]
        public void ContactRemovingTest()
        {
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            app.Contact.DeleteContact(0);
            app.Nav.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllFromDB();
            List<ContactData> contacts = new List<ContactData>(oldContacts);
            contacts.RemoveAt(0);
            contacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(contacts, newContacts);



        }

        [Test]
        public void ContactRemovingFromListTest()
        {
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            app.Contact.DeleteContactFromList(0);
            app.Nav.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllFromDB();
            List<ContactData> contacts = new List<ContactData>(oldContacts);
            contacts.RemoveAt(0);
            contacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(contacts, newContacts);
        }

    }
}
