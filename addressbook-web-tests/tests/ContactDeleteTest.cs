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
    public class ContactDeleteTests : TestBase
    {


        [Test]
        [Ignore("Skip this test")]
        public void ContactDeleteTest()
        {
            app.Contacts.Delete(2);
                      
        }




    
        
      



   

    }
}
