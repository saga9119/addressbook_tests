using NUnit.Framework;

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
    }
}
