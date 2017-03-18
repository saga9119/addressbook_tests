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
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

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

        public bool IsAtLeastOneContact()
        {
            manager.Nav.GoToContactsPage();
            return IsElementPresent(By.CssSelector("*[name='selected[]']"));
        }
    }
}
