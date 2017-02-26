using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AddressbookWebTests
{
    public class AppSteps
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }

        public AppSteps()
        {
               
        } 

        
        public void SetupTest()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }

        
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



        public void WaitForText(string text)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 5) Assert.Fail("Timeout! Text '" + text + "' is not appeared on page in " + second +" seconds.");
                try
                {
                    if ((driver.FindElements(By.XPath("//*[contains(text(),'"+text+"')]"))).Count > 0) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

       

        public void InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToNewContactPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }


        public string[] GetContactNames()
        {
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


        public string[] GetGroupNames()
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

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void ReturnToGroupsPage()
        {
            GoToGroupsName();
        }

        public void Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void GoToGroupsName()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }




        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public bool IsElementPresent(By by)
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

        public bool IsAlertPresent()
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

        public string CloseAlertAndGetItsText()
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
