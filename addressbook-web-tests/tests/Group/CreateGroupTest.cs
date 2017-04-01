using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupTest : AuthTestBase
    {

        [Test]
        public void CreateGroupWithoutParentTest()
        {
            List<GroupData> oldGroups = app.Group.GetGroupsList();
            GroupData group = new GroupData() {
                Name = "name" + System.Diagnostics.Stopwatch.GetTimestamp()

        };
            
            app.Group.CreateGroup(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupsCount());

            List<GroupData> newGroups = app.Group.GetGroupsList();
            newGroups.Sort();
            group.GroupId = newGroups.Find(g => (g.Name == group.Name)).GroupId;

            oldGroups.Add(group);
            oldGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }


        [Test]
        public void CreateGroupBadNameTest()
        {
            List<GroupData> oldGroups = app.Group.GetGroupsList();
            GroupData group = new GroupData() { Name = "a'a" };
            app.Group.CreateGroup(group);
            app.Nav.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupsCount() );

        }
    }
}
