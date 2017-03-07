using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class NavigationHelper : BaseHelper
    {
        protected string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public NavigationHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            return this;
        }

        public NavigationHelper ReturnToGroupsPage()
        {
            GoToGroupsPage();
            return this;
        }

        public NavigationHelper GoToNewContactPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            return this;
        }
    }
}
