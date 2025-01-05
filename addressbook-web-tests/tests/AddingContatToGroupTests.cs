using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using aWebAddressbookTests;

namespace WebAddressbookTests
{
    public class AddingContatToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() 
        {

            List<ContactData> contact4 = ContactData.GetAll();
            if (contact4.Count == 0)
            {
                ContactData contact5 = new ContactData("TEST99", "Test99", "");
                app.Contacts.CreateContact(contact5);
            }


            List<GroupData> group1 = GroupData.GetAll();
            if (group1.Count == 0)
            {
                GroupData group2 = new GroupData("Test99");
                group2.Header = "";
                group2.Footer = "";

                app.Groups.CreateGroup(group2);

            }


            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //action
            app.Contacts.AddContactToGroup(contact, group);
            //end actions


            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
