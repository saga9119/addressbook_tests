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
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            group.Name = "name" + timestamp;
            group.Header = "header" + timestamp;
            group.Footer = "footer" + timestamp;

            string[] groupNames = app.Group.CreateGroup(group).GetGroupNames();

            Assert.Contains(group.Name, groupNames);
        }

        
    }
}
