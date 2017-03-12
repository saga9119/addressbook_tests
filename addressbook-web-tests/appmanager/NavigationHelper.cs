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
            if (driver.Url == baseURL + "/addressbook/group.php" &&
                    (IsElementPresent(By.Name("new"))))
            {
                return this;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public NavigationHelper OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return this;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            return this;
        }

        public NavigationHelper GoToContactsPage()
        {
            OpenHomePage();
            return this;
        }

        public NavigationHelper ReturnToGroupsPage()
        {
            GoToGroupsPage();
            return this;
        }

        public NavigationHelper GoToNewContactPage()
        {
            OpenHomePage();
            return this;
        }
    }
}
