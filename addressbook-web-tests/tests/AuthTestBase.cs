using NUnit.Framework;

namespace AddressbookWebTests
{
    public class AuthTestBase : TestBase
    {

        [SetUp]
        public void SetupLogin()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
