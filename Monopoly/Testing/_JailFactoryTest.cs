using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolopolyGame.Testing
{
    [TestFixture]
    public class _JailFactoryTest
    {
        //global instances for testing
        JailFactory jFact = new JailFactory();

        [Test]
        //simple test for create method
        public void test_create()
        {
            jFact.create("Jail", true);
            Assert.NotNull(jFact);
        }
    }
}
