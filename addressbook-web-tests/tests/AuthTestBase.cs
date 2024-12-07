using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAddressbookTests;

namespace aWebAddressbookTests
{
    public class AuthTestBase :TestBase
    {
        [OneTimeSetUp]
        public void SetupLogin()
        {
          
            app.Auth.Login(new AccountData("admin", "secret"));

        }

    }
}
