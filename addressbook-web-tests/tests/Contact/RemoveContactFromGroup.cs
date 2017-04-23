using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace AddressbookWebTests
{
    [TestFixture]
    public class RemoveContactFromGroup : ContactTestBase
    {

        [Test]
        public void RemoveContactFromGroupTest()
        {
            // prepare and add contact
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldContacts = group.GetContacts();
            ContactData contact = ContactData.GetAllFromDB().Except(oldContacts).First();
            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newContacts = group.GetContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            // delete contact
            app.Contact.RemoveContactFromGroup(contact, group);
            List<ContactData> contactsAfterRemoving = group.GetContacts();
            oldContacts.Remove(contact);
            contactsAfterRemoving.Sort();
            Assert.AreEqual(oldContacts, contactsAfterRemoving);

        }
    }
}
