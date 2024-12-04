using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
      
        [Test]
        [Ignore("Skip this test")]
        public void ContactCreationTest()
        {
             
            ContactData contact = new ContactData("Fistname1", "Lastname1");
            app.Contacts.CreateContact(contact);

            
        }

        [Test]
        [Ignore("Skip this test")]
        public void EmptyContactCreationTest()
        {
                       
            ContactData contact = new ContactData("", "");
            app.Contacts.CreateContact(contact);


        }





    }
}
