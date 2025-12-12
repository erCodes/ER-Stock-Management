using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ER_Stock_Management_DataLibrary;

namespace ER_Stock_Management_Tests.DataLibrary_Tests
{
    [TestFixture]
    internal class MethodsTests
    {
        readonly List<string> SomeList = ["Test"];
        readonly List<string> EmptyList = [];
        readonly List<string>? NullList = null;
        readonly string? NullString = null;
        readonly string TestString = " Test ";

        [Test]
        public void IsEmpty()
        {
            Assert.That(SomeList.Empty(), Is.False);
            Assert.That(EmptyList.Empty(), Is.True);
            Assert.That(NullList.Empty(), Is.True);
        }

        [Test]
        public void TrimNullSafe()
        {
            Assert.That(NullString.TrimNullSafe(), Is.EqualTo(string.Empty));
            Assert.That(TestString.TrimNullSafe(), Is.EqualTo("Test"));
        }
    }
}
