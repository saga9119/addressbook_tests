using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class EditContactTest : ContactTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData();
            contact.Lastname = "edited" + System.Diagnostics.Stopwatch.GetTimestamp();

            app.Nav.GoToContactsPage();

            string[] oldContacts = app.Contact.GetContactNames();
            string[] editedContacts = app.Contact.EditContact(1, contact).GetContactNames();

            Assert.Contains(contact.Lastname, editedContacts);
            Assert.True(oldContacts.Length == editedContacts.Length, "Editing of contact changed number of contacts");
            Assert.That(editedContacts, Has.No.Member(oldContacts[0]));
        }
    }
}
