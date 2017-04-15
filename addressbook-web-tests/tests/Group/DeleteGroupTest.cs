using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteGroupTest : GroupTestBase
    {

        [Test]
        public void GroupRemovingTest()
        {
            List<GroupData> oldGroups = app.Group.GetGroupsList();
            app.Group.DeleteGroup(0);
            Assert.AreEqual(app.Group.GetGroupsCount(), oldGroups.Count - 1 );
            oldGroups.RemoveAt(0);
            List<GroupData> newGroups = app.Group.GetGroupsList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,  newGroups);
        }
    }
}
