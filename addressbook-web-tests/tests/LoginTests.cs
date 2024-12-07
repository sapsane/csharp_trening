using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using WebAddressbookTests;



namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests :TestBase
    {
        [Test]
        [Ignore("Skip this test")]
        public void LoginWithValidCredentials() 
        {
        app.Auth.logout();

            AccountData account = new AccountData("admin", "secret");
        app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));    

        }


        [Test]
        [Ignore("Skip this test")]
        public void LoginWithInValidCredentials()
        {
            app.Auth.logout();

            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }

    }
}
