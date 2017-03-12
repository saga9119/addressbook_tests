using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }


        [Test]
        public void LoginWithInvalidCredentials()
        {
            AccountData account = new AccountData("admin", "1234");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
