using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class DeleteGroupTest : TestBase
    {

        [Test]
        public void GroupRemovingTest()
        {
            app.Group.DeleteGroup(1);
        }
    }
}
