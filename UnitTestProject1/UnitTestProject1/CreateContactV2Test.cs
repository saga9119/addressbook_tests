using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateContactV2Test
    {
        private AppSteps app = new AppSteps();

        [SetUp]
        public void SetupTest()
        {
            app.SetupTest();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            app.TeardownTest();
        }


        [Test]
        public void ContactCreationV2Test()
        {
          
            app.OpenHomePage();
            AccountData user = new AccountData();
            user.Username = "admin";
            user.Password = "secret";
            Login(user);

            app.GoToNewContactPage();
            app.InitNewContactCreation();

            ContactData contact = new ContactData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            contact.Lastname = contact.Lastname + timestamp;
            FillContactForm(contact);
            app.Submit();

            app.WaitForText("Number of results:");

            String[] contacts = app.GetContactNames();
            Assert.Contains(contact.Lastname, contacts);

            app.Logout();
        }


        private void Login(AccountData user)
        {
            app.Driver.FindElement(By.Name("user")).SendKeys(user.Username);
            app.Driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            app.Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
            app.Driver.FindElement(By.Name("firstname")).Clear();
            app.Driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            app.Driver.FindElement(By.Name("middlename")).Clear();
            app.Driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            app.Driver.FindElement(By.Name("lastname")).Clear();
            app.Driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            app.Driver.FindElement(By.Name("nickname")).Clear();
            app.Driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            app.Driver.FindElement(By.Name("title")).Clear();
            app.Driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            app.Driver.FindElement(By.Name("company")).Clear();
            app.Driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            app.Driver.FindElement(By.Name("address")).Clear();
            app.Driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            app.Driver.FindElement(By.Name("home")).Clear();
            app.Driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            app.Driver.FindElement(By.Name("mobile")).Clear();
            app.Driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            app.Driver.FindElement(By.Name("work")).Clear();
            app.Driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            app.Driver.FindElement(By.Name("fax")).Clear();
            app.Driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            app.Driver.FindElement(By.Name("email")).Clear();
            app.Driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            app.Driver.FindElement(By.Name("email2")).Clear();
            app.Driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            app.Driver.FindElement(By.Name("email3")).Clear();
            app.Driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            app.Driver.FindElement(By.Name("homepage")).Clear();
            app.Driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            new SelectElement(app.Driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(app.Driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            app.Driver.FindElement(By.Name("byear")).Clear();
            app.Driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            new SelectElement(app.Driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(app.Driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            app.Driver.FindElement(By.Name("ayear")).Clear();
            app.Driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            app.Driver.FindElement(By.Name("address2")).Clear();
            app.Driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            app.Driver.FindElement(By.Name("phone2")).Clear();
            app.Driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            app.Driver.FindElement(By.Name("notes")).Clear();
            app.Driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
        }

    }
}
