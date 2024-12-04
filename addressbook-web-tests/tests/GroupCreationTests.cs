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
       // [Ignore("Skip this test")]
        public void GroupCreationTest()
        {
                    
            GroupData group = new GroupData("GroupName1");
            group.Header = "header1";
            group.Footer = "footer";

            app.Groups.CreateGroup(group);
            
           
        }


        [Test]
       // [Ignore("Skip this test")]
        public void EmptyGroupCreationTest()
        {

            

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
            

        }


    }
}
