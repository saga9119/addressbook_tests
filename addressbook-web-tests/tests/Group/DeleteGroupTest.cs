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
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            GroupData toBeRemoved = oldGroups[0];
            app.Group.DeleteGroup(toBeRemoved);
            Assert.AreEqual(app.Group.GetGroupsCount(), oldGroups.Count - 1 );
            oldGroups.RemoveAt(0);
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,  newGroups);
            app.Nav.GoToContactsPage();
        }
    }
}
