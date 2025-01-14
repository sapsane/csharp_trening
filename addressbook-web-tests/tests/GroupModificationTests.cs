﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aWebAddressbookTests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {

        [Test]
        //[Ignore("Skip this test")]
        public void GroupModificationTest()
        {
            if ( ! app.Groups.IsGroupPresent())
            {
                GroupData group = new GroupData("GroupName NEW");
                group.Header = "header new";
                group.Footer = "footer new";

                app.Groups.CreateGroup(group);
            }

            

            GroupData newData = new GroupData("Group_Modify_Name2");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData ToBeModify = oldGroups[0];

            app.Groups.Modify(ToBeModify, newData);

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name=newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);


        }


    }
}
