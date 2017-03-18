using NUnit.Framework;

namespace AddressbookWebTests
{
    public class GroupTestBase : TestBase
    {

        [SetUp]
        public void CreateGroupIfNone()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));

            if (!app.Group.IsAtLeastOneGroup())
            {
                app.Group.CreateGroup(new GroupData());
            }

        }
    }
}
