using System;
using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {

        [Test]
        public void CreateContactWithoutGroupTestTest()
        {
            ContactData contact = new ContactData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            contact.Lastname = contact.Lastname + timestamp;

            String[] contacts = app.Contact.CreateContact(contact).GetContactNames();

            Assert.Contains(contact.Lastname, contacts);
        }


    }
}
