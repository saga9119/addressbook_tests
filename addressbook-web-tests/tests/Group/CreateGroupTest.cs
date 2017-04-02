using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupTest : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for(int i = 0;  i < 5; i++)
            {
                groups.Add(new GroupData() {
                    Name = GenerateRandomString(30),
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateGroupWithoutParentTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Group.GetGroupsList();
            app.Group.CreateGroup(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupsCount());

            List<GroupData> newGroups = app.Group.GetGroupsList();
            newGroups.Sort();
            group.GroupId = newGroups.Find(g => (g.Name == group.Name)).GroupId;

            oldGroups.Add(group);
            oldGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
