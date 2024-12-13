using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aWebAddressbookTests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        //[Ignore("Skip this test")]
        public void ContactModificationTest()
        {
            if (! app.Contacts.IsContactPresent())
            {
                ContactData contact1 = new ContactData("Fistname NEW", "Lastname NEW", "" );
                app.Contacts.CreateContact(contact1);
            }


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData("MODIFY firstname", "Modify LastName", "");

            app.Contacts.ModifyContact(0,contact);


            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname= contact.Firstname;
            oldContacts[0].Lastname= contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);



        }


    }
}
