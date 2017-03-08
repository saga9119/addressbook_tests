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
            string[] contacts = app.Contact.CreateContact(contact).GetContactNames();
            Assert.Contains(contact.Lastname, contacts);
        }
    }
}
