using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolopolyGame.Testing
{
    [TestFixture]
    public class _JailTest
    {
        //create global instances to use to test with
        private Jail theTestPlayer = new Jail();

        [Test]
        public void test_isJailProperty()
        {
            theTestPlayer.isJailProperty();
            Assert.NotNull(theTestPlayer);
        }

        [Test]
        public void test_ToString()
        {
            theTestPlayer.ToString();
            Assert.NotNull(theTestPlayer);
        }
    }
}
