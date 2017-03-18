using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteContactTest : ContactTestBase
    {
        [Test]
        public void ContactRemovingTest()
        {
            app.Contact.DeleteContact(1);
        }

        [Test]
        public void ContactRemovingFromListTest()
        {
            app.Contact.DeleteContactFromList(1);
        }

    }
}
