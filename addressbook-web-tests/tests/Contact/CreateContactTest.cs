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
            ContactData contact = new ContactData().AutoFill();
        

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
