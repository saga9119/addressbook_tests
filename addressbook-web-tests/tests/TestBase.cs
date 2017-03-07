using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Nav.OpenHomePage();
            AccountData user = new AccountData();
            user.Username = "admin";
            user.Password = "secret";
            app.Auth.Login(user);
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
