using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressbookWebTests
{
    public class ContactHelper :BaseHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        private List<ContactData> contactCache = null;

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Nav.GoToContactsPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            string homepage = cells[9].FindElement(By.TagName("a")).GetAttribute("href");

            return new ContactData()
            {
                Firstname = firstname,
                Lastname = lastname,
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones,
                Homepage = homepage
            };

        }

        public ContactData GetContactInformationFromCard(int index)
        {
            manager.Nav.OpenHomePage();
            ViewContactCard(index);
            return new ContactData()
            {
                Card = driver.FindElement(By.CssSelector("div#content")).Text.Replace("\r\n", "").Replace(" ", "")
            };
            
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Nav.OpenHomePage();
            InitContactEdit(index);

            
            return new ContactData()
            {
                Firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value"),
                Middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value"),
                Lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value"),
                Nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value"),
                Title = driver.FindElement(By.Name("title")).GetAttribute("value"),
                Company = driver.FindElement(By.Name("company")).GetAttribute("value"),
                Address = driver.FindElement(By.Name("address")).GetAttribute("value"),
                Home = driver.FindElement(By.Name("home")).GetAttribute("value"),
                Mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                Work = driver.FindElement(By.Name("work")).GetAttribute("value"),
                Phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value"),
                Fax = driver.FindElement(By.Name("fax")).GetAttribute("value"),
                Email = driver.FindElement(By.Name("email")).GetAttribute("value"),
                Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value"),
                Homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value"),
                Bday = driver.FindElement(By.Name("bday")).GetAttribute("value"),
                Bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value"),
                Byear = driver.FindElement(By.Name("byear")).GetAttribute("value"),
                Aday = driver.FindElement(By.Name("aday")).GetAttribute("value"),
                Amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value"),
                Ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value"),
                Address2 = driver.FindElement(By.Name("address2")).GetAttribute("value"),
                Notes = driver.FindElement(By.Name("notes")).GetAttribute("value")
            };

    }

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

        public ContactHelper ViewContactCard(int index)
        {
            driver.FindElements(By.CssSelector("*[title='Details']"))[index].Click();
            return this;
        }

        public bool IsAtLeastOneContact()
        {
            manager.Nav.GoToContactsPage();
            return IsElementPresent(By.CssSelector("*[name='selected[]']"));
        }

        public int GetNumOfSearchResults()
        {
            manager.Nav.GoToContactsPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
