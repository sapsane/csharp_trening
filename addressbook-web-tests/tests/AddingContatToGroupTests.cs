using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using aWebAddressbookTests;

namespace WebAddressbookTests
{
    public class AddingContatToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() 
        {
            GroupData group = GroupData.GetAll()[0];
        }
    }
}
