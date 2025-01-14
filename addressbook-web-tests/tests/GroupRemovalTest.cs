﻿using System;
using System.Collections.Generic;
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
    public class GroupRemovalTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData ToBeRemoved = oldGroups[0];

            app.Groups.Remove(ToBeRemoved);

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, ToBeRemoved.Id);
            }



        }

      
    }
}
