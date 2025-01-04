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
    public class ContactDeleteTests : ContactTestBase
    {


        [Test]
        //[Ignore("Skip this test")]
        public void ContactDeleteTest()
        {
            if ( ! app.Contacts.IsContactPresent()) 
            {
                ContactData contact = new ContactData("Fistname NEW", "Lastname NEW", ""  );
                app.Contacts.CreateContact(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData ToBeRemoved = oldContacts[0];

            app.Contacts.Delete(ToBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, ToBeRemoved.Id);
            }


        }

       
    }
}
