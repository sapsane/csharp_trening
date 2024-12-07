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
        [Ignore("Skip this test")]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("MODIFY firstname", "Modify LastName");
            app.Contacts.ModifyContact(2,contact);

        }


    }
}
