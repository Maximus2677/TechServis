using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Api;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;
using NUnit.Framework.Internal.Commands;
using NUnit.Framework.Internal.Execution;
using NUnit.Framework.Legacy;

namespace TechServis
{
    [TestFixture]
    internal class md5Tests
    {
        [Test]
        public void testMd5()
        {
            string a = "1";
            string expeced = "C4CA4238A0B923820DCC509A6F75849B";

            string actual = md5.hashPassword(a);

            Assert.That(expeced, Is.EqualTo(actual));
        }
    }
}
