using NUnit.Framework;
using System;
using System.Text;

namespace AddressbookWebTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            if (app.Auth.IsLoggedIn())
            {
                app.Auth.Logout();
            }

        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int length = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
               builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }


    }
}
