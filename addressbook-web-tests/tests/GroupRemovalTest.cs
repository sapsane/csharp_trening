using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using aWebAddressbookTests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
     

        [Test]
       // [Ignore("Skip this test")]
        public void GroupRemovalTest()
        {
            if (! app.Groups.IsGroupPresent())
            {
                GroupData group = new GroupData("GroupName NEW");
                group.Header = "header new";
                group.Footer = "footer new";

                app.Groups.CreateGroup(group);
            }

            app.Groups.Remove(1);
         
        }

      
    }
}
