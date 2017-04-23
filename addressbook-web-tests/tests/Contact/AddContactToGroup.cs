using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace AddressbookWebTests
{
    [TestFixture]
    public class AddContactToGroup : AuthTestBase
    {


        [Test]
        public void AddContactToGroupTest()
        {
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldContacts = group.GetContacts();
            ContactData contact = ContactData.GetAllFromDB().Except(oldContacts).First();

            app.Contact.AddContactToGroup(contact, group);


            List<ContactData> newContacts = group.GetContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
