using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteGroupTest : GroupTestBase
    {

        [Test]
        public void GroupRemovingTest()
        {
            app.Group.DeleteGroup(1);
        }
    }
}
