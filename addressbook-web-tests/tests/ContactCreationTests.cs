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


        public static IEnumerable<ContactData> RandomContactDataProvider() 
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++) 
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10), ""));

            }

            return contacts;
        }


        [Test,TestCaseSource("RandomContactDataProvider")]
        //[Ignore("Skip this test")]
        public void ContactCreationTest(ContactData contact)
        {


            List<ContactData> oldContacts = app.Contacts.GetContactList();

           
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
