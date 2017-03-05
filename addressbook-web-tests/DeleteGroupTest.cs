using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteGroupTest : TestBase
    {

        [Test]
        public void GroupRemovingTest()
        {
            GoToGroupsPage();
            SelectGroup(1);
            SubmitDelete();
            ReturnToGroupsPage();
        }
    }
}
