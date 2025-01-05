using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using aWebAddressbookTests;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroup: AuthTestBase
    {
        [Test]

        public void TestRemovedContactFromGroup()
        {
            List<ContactData> contact4 = ContactData.GetAll();
            if (contact4.Count == 0) 
            {
                ContactData contact5 = new ContactData("TEST99", "Test99", "");
                app.Contacts.CreateContact(contact5);
            }
            
            
            List <GroupData> group1 = GroupData.GetAll();
            if (group1.Count == 0)
            {
                GroupData group2 = new GroupData("Test99");
                group2.Header = "";
                group2.Footer = "";

                app.Groups.CreateGroup(group2);
               
            }
            

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList1 = group.GetContacts();
            if (oldList1.Count == 0) 
            {
                ContactData contact1 = ContactData.GetAll().Except(oldList1).First();
                //action
                app.Contacts.AddContactToGroup(contact1, group);
                

            }
            app.Navigator.OpenContactsPage();
            List<ContactData> oldList = group.GetContacts();
            
            ContactData contact = group.GetContacts().First();


            //action
            app.Contacts.RemovedContactFromGroup(contact, group);
           
            //end actions


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
