using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {

        }


        public LoginHelper Login(AccountData user)
        {
            driver.FindElement(By.Name("user")).SendKeys(user.Username);
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            return this;
        }

        public LoginHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

    }
}
