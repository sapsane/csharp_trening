using System;
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
    public class ContactCreationTests : AuthTestBase
    {
      
        [Test]
        //[Ignore("Skip this test")]
        public void ContactCreationTest()
        {


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData("Fistname1", "Lastname1","");
            app.Contacts.CreateContact(contact);
            
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        //[Ignore("Skip this test")]
        public void EmptyContactCreationTest()
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData("", "","");
            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        //[Ignore("Skip this test")]
        public void BadContactCreationTest()
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData("a'a", "", "");
            app.Contacts.CreateContact(contact);


            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }




    }
}
