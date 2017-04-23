using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    public class ContactTestBase : AuthTestBase
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

        [TearDown]
        public void CompareContactsUiDB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = app.Contact.GetContactsList();
                List<ContactData> fromDB = ContactData.GetAllFromDB();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

        }

    }
}
