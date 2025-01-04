using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using aWebAddressbookTests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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



        public static IEnumerable<ContactData> ContactsDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();

            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));



        }




        [Test,TestCaseSource("ContactsDataFromXmlFile")]
        //[Ignore("Skip this test")]
        public void ContactCreationTest(ContactData contact)
        {


            List<ContactData> oldContacts = ContactData.GetAll();


            app.Contacts.CreateContact(contact);
            
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }


        [Test]
        [Ignore("Skip this test")]
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

        [Test]
        //[Ignore("Skip this test")]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine("test1=" + end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();


            end = DateTime.Now;
            System.Console.Out.WriteLine("test2=" + end.Subtract(start));
        }



    }
}
