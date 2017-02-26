using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void CreateGroupWithoutParentTest()
        {
            OpenHomePage();
            AccountData user = new AccountData();
            user.Username = "admin";
            user.Password = "secret";
            Login(user);
            GoToGroupsName();
            InitGroupCreation();

            GroupData group = new GroupData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            group.Name = "name" + timestamp;
            group.Header = "header" + timestamp;
            group.Footer = "footer" + timestamp;
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturnToGroupsPage();

            string[] groupNames = GetGroupNames();
            Assert.Contains(group.Name, groupNames);

            Logout();
        }




        private string[] GetGroupNames()
        {
            System.Collections.Generic.IList<IWebElement> all = driver.FindElements(By.XPath("//span[@class='group']"));
            String[] groupNames = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                groupNames[i++] = element.Text;
            }

            return groupNames;
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToGroupsPage()
        {
            GoToGroupsName();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            new SelectElement(driver.FindElement(By.Name("group_parent_id"))).SelectByText(group.ParentGroupName);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        private void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsName()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }


        private void Login(AccountData user)
        {
            driver.FindElement(By.Name("user")).SendKeys(user.Username);
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
