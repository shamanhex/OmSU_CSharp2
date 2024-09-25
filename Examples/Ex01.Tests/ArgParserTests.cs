using Ex01;
using NUnit.Framework;

namespace Ex01.Tests
{
    [TestFixture]
    public class ArgParserTests
    {
        [Test]
        public void ArgParser_HasArg_ArgExists()
        {
            ArgParser.SetArgs("--version", "--name", "Ivanov I.I.");

            Assert.That(ArgParser.HasArg("--version"), Is.False);
        }
    }
}