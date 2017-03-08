using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteContactTest : TestBase
    {

        [Test]
        public void ContactRemovingTest()
        {
            ContactData contact = new ContactData();
            app.Contact.CreateContact(contact);
            app.Contact.DeleteContact(1);
        }

        [Test]
        public void ContactRemovingFromListTest()
        {
            ContactData contact = new ContactData();
            app.Contact.CreateContact(contact);
            app.Contact.DeleteContactFromList(1);
        }

    }
}
