using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    public class ContactHelper :BaseHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Nav.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData();

                    contact.ContactId = element.FindElement(By.TagName("input")).GetAttribute("id");
                    contact.Firstname = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(3)")).Text;
                    contact.Middlename = null;
                    contact.Lastname = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(2)")).Text;
                    contact.Nickname = null;
                    contact.Title = null;
                    contact.Company = null;
                    contact.Address = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(4)")).Text;
                    contact.Home = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(6)")).Text;
                    contact.Mobile = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(6)")).Text;
                    contact.Work = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(6)")).Text;
                    contact.Fax = null;
                    contact.Email = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(5)")).Text;
                    contact.Email2 = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(5)")).Text;
                    contact.Email3 = element.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(5)")).Text;
                    contact.Homepage = null;
                    contact.Bday = "";
                    contact.Bmonth = "";
                    contact.Byear = "";
                    contact.Aday = "";
                    contact.Amonth = "";
                    contact.Ayear = "";
                    contact.Address2 = null;
                    contact.Phone2 = null;
                    contact.Notes = null;

                    contactCache.Add(contact);
                }

            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        public ContactHelper EditContact(int index, ContactData contact)
        {
            manager.Nav.GoToContactsPage();
            SelectContact(index).InitContactEdit(index).FillContactForm(contact).SubmitUpdateContact();
            contactCache = null;
           manager.Nav.GoToContactsPage();
            return this;
        }



        public ContactHelper DeleteContact(int index)
        {
            manager.Nav.GoToContactsPage();
            SelectContact(index)
                .InitContactRemoving(index)
                .SubmitDeleteContact();
            contactCache = null;
            manager.Nav.GoToContactsPage();
            return this;
        }

        public ContactHelper DeleteContactFromList(int index)
        {
            manager.Nav.GoToContactsPage();
            SelectContact(index)
                .SubmitDeleteContact();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + (index + 1) + "]")).Click();
            return this;
        }


        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Nav.GoToNewContactPage();

            InitNewContactCreation();
            FillContactForm(contact);
            Submit();
            contactCache = null;
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
//            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
//            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
//            Type(By.Name("byear"), contact.Byear);
//            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
//            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
//            Type(By.Name("ayear"), contact.Ayear);
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
            driver.FindElements(By.CssSelector("*[title='Edit']"))[index].Click();
            return this;
        }


        public bool IsAtLeastOneContact()
        {
            manager.Nav.GoToContactsPage();
            return IsElementPresent(By.CssSelector("*[name='selected[]']"));
        }
    }
}
