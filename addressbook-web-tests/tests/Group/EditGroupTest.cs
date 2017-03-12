using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class EditGroupTest : GroupTestBase
    {

        [SetUp]
        public void CreateGroupIfNone()
        {
            if (!app.Group.IsAtLeastOneGroup())
            {
                app.Group.CreateGroup(new GroupData());
            }
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            group.Name = "name" + timestamp;
            group.Header = "header" + timestamp;
            group.Footer = "footer" + timestamp;

            app.Nav.GoToGroupsPage();
            string[] oldGroups = app.Group.GetGroupNames();
            string[] editedGroups = app.Group.EditGroup(1, group).GetGroupNames();

            Assert.Contains(group.Name, editedGroups);
            Assert.True(oldGroups.Length == editedGroups.Length, "Editing of group changed number of groups");
            Assert.That(editedGroups, Has.No.Member(oldGroups[0]));
        }
    }
}
