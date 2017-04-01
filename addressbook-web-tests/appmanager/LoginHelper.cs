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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user))
                {
                    return this;
                }
                Logout();

            }

            Type(By.Name("user"), user.Username);
            Type(By.Name("pass"), user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && 
                (GetLoggedUserName() == account.Username);
        }

        public LoginHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

    }
}
