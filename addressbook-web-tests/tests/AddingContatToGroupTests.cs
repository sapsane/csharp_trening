using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using aWebAddressbookTests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContatToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() 
        {

            List<ContactData> contact4 = ContactData.GetAll();
            if (contact4.Count == 0)
                //добавляем контакт если контактов нет
            {
                ContactData contact5 = new ContactData("TEST99", "Test99", "");
                app.Contacts.CreateContact(contact5);
            }


            List<GroupData> group1 = GroupData.GetAll();

            if (group1.Count == 0)
            //добавляем группу если группы нет
            {
                GroupData group2 = new GroupData("GroupNew");
                group2.Header = "";
                group2.Footer = "";

                app.Groups.CreateGroup(group2);

            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List <ContactData> contact2 = ContactData.GetAll().Except(oldList).ToList();
            if (contact2.Count == 0) 
            {
                //если контакты в группе добывлены все (контакты минус контакты в группе) 
                ContactData contact7 = new ContactData("TEST77new", "Test77new", "");
                app.Contacts.CreateContact(contact7);
                
            }
            app.Navigator.OpenContactsPage();
            GroupData group3 = GroupData.GetAll()[0];
            List<ContactData> oldList3 = group3.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList3).First();

            //action
            app.Contacts.AddContactToGroup(contact, group3);
            //end actions


            List<ContactData> newList = group.GetContacts();
            oldList3.Add(contact);
            newList.Sort();
            oldList3.Sort();
            Assert.AreEqual(oldList3, newList);

        }
    }
}
