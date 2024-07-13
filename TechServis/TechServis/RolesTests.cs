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
    internal class RolesTests
    {
        [Test]
        public void true_true_admin()
        {
            bool ad = true;
            bool man= true;
            string expeced = "admin";

            Roles roles = new Roles();
            roles.SetAd(ad);
            roles.SetMan(man);
            string actual = roles.GetRole();

            Assert.That(expeced, Is.EqualTo(actual));
        }

        [Test]
        public void false_true_manager()
        {
            bool ad = false;
            bool man = true;
            string expeced = "manager";

            Roles roles = new Roles();
            roles.SetAd(ad);
            roles.SetMan(man);
            string actual = roles.GetRole();

            Assert.That(expeced, Is.EqualTo(actual));
        }
    }
}
