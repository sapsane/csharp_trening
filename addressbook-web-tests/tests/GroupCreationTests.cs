using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
      

        [Test]
        [Ignore("Skip this test")]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();

            app.Auth.Login(new AccountData("admin", "secret"));

            app.Navigator.GoToGroupsPage();

            app.Groups.InitGroupCreation();

            GroupData group = new GroupData("GroupName1");
            group.Header = "header1";
            group.Footer = "footer";
            app.Groups.FillGroupForm(group);

            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
           


        }
        
        
    }
}
