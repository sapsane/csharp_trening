﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using aWebAddressbookTests;

//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider() 
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++) 
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(40),
                    Footer = GenerateRandomString(40)
                });

            }
            return groups;
        }

       

        [Test,TestCaseSource("RandomGroupDataProvider")]
       //[Ignore("Skip this test")]
        public void GroupCreationTest(GroupData group)
        {
    
            
            

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CreateGroup(group);
            
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
           
        }


       


        
        [Test]
        //[Ignore("Skip this test")]
        public void BadNameGroupCreationTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.CreateGroup(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
        


    }
}
