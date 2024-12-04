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
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        //[Ignore("Skip this test")]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();

            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.OpenContactsPage();
            app.Contacts.InitContactCreation();

            app.Contacts.FillContactForm(new ContactData("Fistname1","Lastname1"));
            app.Contacts.SubminContactCreation();
            app.Contacts.ReturnToContactsPage();
            
        }

    
        
              
   

     
    }
}
