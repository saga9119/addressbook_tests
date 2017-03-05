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
            GoToNewContactPage();
            InitNewContactCreation();

            ContactData contact = new ContactData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            contact.Lastname = contact.Lastname + timestamp;
            FillContactForm(contact);
            Submit();

            WaitForText("Number of results:");

            String[] contacts = GetContactNames();
            Assert.Contains(contact.Lastname, contacts);
        }
    }
}
