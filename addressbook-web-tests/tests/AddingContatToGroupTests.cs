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
