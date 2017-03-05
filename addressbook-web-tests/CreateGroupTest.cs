using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupTest : TestBase
    {

        [Test]
        public void CreateGroupWithoutParentTest()
        {
            GoToGroupsPage();
            InitGroupCreation();

            GroupData group = new GroupData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            group.Name = "name" + timestamp;
            group.Header = "header" + timestamp;
            group.Footer = "footer" + timestamp;
            FillGroupForm(group);

            Submit();
            ReturnToGroupsPage();

            string[] groupNames = GetGroupNames();
            Assert.Contains(group.Name, groupNames);
        }
    }
}
