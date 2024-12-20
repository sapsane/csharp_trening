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
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        //[Ignore("Skip this test")]

        public void TestContactInformation() {
           ContactData fromTable =  app.Contacts.GetContactInformationFromTable(0 );
           ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0 );


            //verifications
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);


        }

    }
}
