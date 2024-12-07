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

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        [Ignore("Skip this test")]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group_Modify_Name2");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }


    }
}
