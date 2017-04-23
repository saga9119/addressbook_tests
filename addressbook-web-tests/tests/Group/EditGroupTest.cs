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
            List<GroupData> oldGroups = GroupData.GetAllFromDB();

            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            GroupData group = new GroupData() {
                Name = "name_edited_at" + timestamp,
                Header = "header_edited_at" + timestamp,
                Footer = "footer_edited_at" + timestamp
        };
            
            app.Group.EditGroup(0, group);
            Assert.AreEqual(app.Group.GetGroupsCount(), oldGroups.Count);

            List<GroupData> newGroups = GroupData.GetAllFromDB();
            group.GroupId = newGroups.Find(g => (g.Name == group.Name)).GroupId;
            oldGroups[0] = group;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
