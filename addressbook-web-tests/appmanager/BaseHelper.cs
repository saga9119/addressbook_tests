using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected WaitHelper wait;
        protected ApplicationManager manager;

        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }



        public BaseHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public BaseHelper SubmitDelete()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public BaseHelper SubmitUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


        public WaitHelper Wait
        {
            get
            {
                return wait;
            }
        }



    }
}
