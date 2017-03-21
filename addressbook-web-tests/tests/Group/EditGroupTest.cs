using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class EditGroupTest : GroupTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            
            app.Nav.GoToGroupsPage();
            List<GroupData> oldGroups = app.Group.GetGroupsList();

            GroupData group = new GroupData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            group.Name = "name_edited_at" + timestamp;
            group.Header = "header_edited_at" + timestamp;
            group.Footer = "footer_edited_at" + timestamp;

            app.Group.EditGroup(0, group);
            Assert.AreEqual(app.Group.GetGroupsCount(), oldGroups.Count);

            List<GroupData> newGroups = app.Group.GetGroupsList();
            group.GroupId = oldGroups[0].GroupId;
            oldGroups[0] = group;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
