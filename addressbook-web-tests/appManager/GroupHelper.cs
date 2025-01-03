using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

       

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
           
        }

        public GroupHelper CreateGroup(GroupData group) 
        {
              manager.Navigator.GoToGroupsPage();
              InitGroupCreation();
              FillGroupForm(group);
              SubmitGroupCreation();
              ReturnToGroupsPage();

            return this;
        }



        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup2(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup2(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }



        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup2(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }


        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCashe = null;
            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }


        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }



        public GroupHelper FillGroupForm(GroupData group)
        {
          
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }

 

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }


        public  bool  IsGroupPresent()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.Name("selected[]"));
             
        }


        private List<GroupData> groupCashe= null;

        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null) 
            {
                groupCashe=new List<GroupData>();

                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    GroupData group = new GroupData(element.Text) 
                    {
                    Id= element.FindElement(By.TagName("input")).GetDomAttribute("value")
                    };
                                        
                    groupCashe.Add(group);
                }

            }

            return new List<GroupData>(groupCashe) ;
        }

    
    }
}
