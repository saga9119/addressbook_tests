using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;


namespace AddressbookWebTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected WaitHelper waitHelper;


        public ApplicationManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();

            loginHelper = new LoginHelper(this);
            navHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            waitHelper = new WaitHelper(this);

        }

        public void Stop()
        {
            Auth.Logout();

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


        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public WaitHelper Wait
        {
            get
            {
                return waitHelper;
            }
        }

        public NavigationHelper Nav
        {
            get
            {
                return navHelper;
            }
        }

        public GroupHelper Group
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
