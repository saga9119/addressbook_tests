using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    public class GroupHelper : BaseHelper
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper DeleteGroup(GroupData group)
        {
            manager.Nav.GoToGroupsPage();
            SelectGroup(group).SubmitDelete();
            groupCache = null;
            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper DeleteGroup(int index)
        {
            manager.Nav.GoToGroupsPage();
            SelectGroup(index).SubmitDelete();
            groupCache = null;
            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupsList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Nav.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add( new GroupData()
                    {
                        Name = element.Text,
                        Header = null,
                        Footer = null,
                        ParentGroupName = null,
                        GroupId = element.FindElement(By.TagName("input")).GetAttribute("value")

                    });
                }
                    string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                    string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                    for(int i = 0; i < groupCache.Count; i++)
                    {
                        if(i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                        else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                    

                    }
            }
            return  new List<GroupData>(groupCache);
        }


        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Nav.GoToGroupsPage();
            InitGroupCreation()
            .FillGroupForm(group)
            .Submit();
            groupCache = null;
            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper EditGroup(int index, GroupData group)
        {
            manager.Nav.GoToGroupsPage();
            SelectGroup(index).InitGroupEdit().FillGroupForm(group).SubmitUpdate();
            groupCache = null;
            manager.Nav.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(GroupData group)
        {
            int id = Convert.ToInt32(group.GroupId);
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
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


        public int GetGroupsCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
//            new SelectElement(driver.FindElement(By.Name("group_parent_id"))).SelectByText(group.ParentGroupName);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public bool IsAtLeastOneGroup()
        {
            manager.Nav.GoToGroupsPage();
            return IsElementPresent(By.CssSelector("*[name='selected[]']"));
        }

    }
}
