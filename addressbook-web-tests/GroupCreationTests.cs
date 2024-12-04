﻿using System;
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
            OpenHomePage();

            Login(new AccountData("admin", "secret"));

            GoToGroupsPage();

            InitGroupCreation();

            GroupData group = new GroupData("GroupName1");
            group.Header = "header1";
            group.Footer = "footer";
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();


        }
        
        
    }
}
