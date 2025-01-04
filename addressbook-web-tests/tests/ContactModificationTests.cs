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
    public class ContactModificationTests : ContactTestBase
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


            List<ContactData> oldContacts = ContactData.GetAll();
            oldContacts.Sort();
            ContactData ToBeModify = oldContacts[0];

            ContactData contact = new ContactData("MODIFY1 firstname1", "Modify1 LastName1", "");

            app.Contacts.ModifyContact(ToBeModify, contact);


            
            oldContacts[0].Firstname= contact.Firstname;
            oldContacts[0].Lastname= contact.Lastname;
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);



        }


    }
}
