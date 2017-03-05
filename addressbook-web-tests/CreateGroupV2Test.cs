using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AddressbookWebTests
{
    [TestFixture]
    public class CreateGroupV2Test
    {
        private AppSteps app = new AppSteps();

        [SetUp]
        public void SetupTest()
        {
            app.SetupTest();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            app.TeardownTest();
        }


        [Test]
        public void GroupCreationV2Test()
        {

            app.OpenHomePage();
            AccountData user = new AccountData();
            user.Username = "admin";
            user.Password = "secret";
            Login(user);
            app.GoToGroupsName();
            app.InitGroupCreation();

            GroupData group = new GroupData();
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            group.Name = "name" + timestamp;
            group.Header = "header" + timestamp;
            group.Footer = "footer" + timestamp;
            FillGroupForm(group);

            app.Submit();
            app.ReturnToGroupsPage();

            string[] groupNames = app.GetGroupNames();
            Assert.Contains(group.Name, groupNames);

            app.Logout();
        }


        private void Login(AccountData user)
        {
            app.Driver.FindElement(By.Name("user")).SendKeys(user.Username);
            app.Driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            app.Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }


        private void FillGroupForm(GroupData group)
        {
            app.Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            new SelectElement(app.Driver.FindElement(By.Name("group_parent_id"))).SelectByText(group.ParentGroupName);
            app.Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            app.Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }



    }
}
