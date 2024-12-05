using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase   
    {

        [Test]
        [Ignore("Skip this test")]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group_Modify_Name1");
            newData.Header = "header2";
            newData.Footer = "footer2";

            app.Groups.Modify(1, newData);
        }


    }
}
