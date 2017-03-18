using NUnit.Framework;

namespace AddressbookWebTests
{
    public class ContactTestBase : TestBase
    {

        [SetUp]
        public void CreateContactIfNone()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));

            if (!app.Contact.IsAtLeastOneContact())
            {
                ContactData contact = new ContactData();
                app.Contact.CreateContact(contact);
            }
        }

    }
}
