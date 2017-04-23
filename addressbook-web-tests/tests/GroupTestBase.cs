using NUnit.Framework;
using System.Collections.Generic;

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

        [TearDown]
        public void CompareGroupsUiDB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = app.Group.GetGroupsList();
                List<GroupData> fromDB = GroupData.GetAllFromDB();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

        }
    }
}
