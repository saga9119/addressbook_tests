using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupTest : TestBase
    {

        [Test]
        public void CreateGroupWithoutParentTest()
        {
            GroupData group = new GroupData();
            string[] groupNames = app.Group.CreateGroup(group).GetGroupNames();
            Assert.Contains(group.Name, groupNames);
        }
    }
}
