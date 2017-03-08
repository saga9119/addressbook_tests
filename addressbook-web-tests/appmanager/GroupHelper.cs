using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AddressbookWebTests
{
    public class GroupHelper : BaseHelper
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper DeleteGroup(int index)
        {
            manager.Nav.GoToGroupsPage();
            SelectGroup(index).SubmitDelete();
            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Nav.GoToGroupsPage();

            InitGroupCreation()
            .FillGroupForm(group)
            .Submit();

            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper EditGroup(int index, GroupData group)
        {
            manager.Nav.GoToGroupsPage();
            SelectGroup(index).InitGroupEdit().FillGroupForm(group).SubmitUpdate();
            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + index + "]")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper InitGroupEdit()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public string[] GetGroupNames()
        {
            System.Collections.Generic.IList<IWebElement> all = driver.FindElements(By.XPath("//span[@class='group']"));
            String[] groupNames = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                groupNames[i++] = element.Text;
            }

            return groupNames;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            new SelectElement(driver.FindElement(By.Name("group_parent_id"))).SelectByText(group.ParentGroupName);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);

            return this;
        }

    }
}
