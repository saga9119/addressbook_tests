using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AddressbookWebTests
{
    public class WaitHelper : BaseHelper
    {
        public WaitHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void WaitForText(string text)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 5) Assert.Fail("Timeout! Text '" + text + "' is not appeared on page in " + second + " seconds.");
                try
                {
                    if ((driver.FindElements(By.XPath("//*[contains(text(),'" + text + "')]"))).Count > 0) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }


    }
}
