using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AddressbookWebTests
{
    public class ContactHelper :BaseHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper EditContact(int index, ContactData contact)
        {
            manager.Nav.GoToContactsPage();
            SelectContact(index).InitContactEdit(index).FillContactForm(contact).SubmitUpdateContact();
            manager.Nav.GoToContactsPage();
            return this;
        }



        public ContactHelper DeleteContact(int index)
        {
            manager.Nav.GoToContactsPage();
            SelectContact(index)
                .InitContactRemoving(index)
                .SubmitDeleteContact();
            manager.Nav.GoToContactsPage();
            return this;
        }

        public ContactHelper DeleteContactFromList(int index)
        {
            manager.Nav.GoToContactsPage();
            SelectContact(index)
                .SubmitDeleteContact();
            driver.SwitchTo().Alert().Accept();
            manager.Nav.GoToContactsPage();
            return this;
        }

        public ContactHelper SubmitDeleteContact()
        {
            driver.FindElement(By.CssSelector("*[value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitUpdateContact()
        {
            driver.FindElement(By.CssSelector("*[value='Update']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + index + "]")).Click();
            return this;
        }


        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Nav.GoToNewContactPage();

            InitNewContactCreation();
            FillContactForm(contact);
            Submit();
            
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);

            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

       
        public ContactHelper InitContactRemoving(int index)
        {
            InitContactEdit(index);
            return this;
        }

        public ContactHelper InitContactEdit(int index)
        {
            driver.FindElements(By.CssSelector("*[title='Edit']"))[index - 1].Click();
            return this;
        }

        public string[] GetContactNames()
        {
            manager.Wait.WaitForText("Number of results:");
            // only firstname text  
            System.Collections.Generic.IList<IWebElement> all = driver.FindElements(By.CssSelector("tr[name='entry'] td:nth-of-type(2)"));
            String[] contactNames = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                contactNames[i++] = element.Text;
            }

            return contactNames;
        }
    }
}
