using NUnit.Framework;
using PLLab;

namespace PLLabTests
{
    [TestFixture]
    public class ArgParserTests
    {
        [Test]
        public void ArgParser_HasArg_ArgExisted_retTrue()
        {
            ArgParser.SetArgs("--verbose");
            Assert.That(ArgParser.HasArg("--verbose"), "Arg with name --verbose not found.");
        }

        [Test]
        public void ArgParser_HasArg_ArgNotExisted_retFalse()
        {
            ArgParser.SetArgs("--Name", "Ivanov");
            Assert.That(!ArgParser.HasArg("--verbose"), "Arg with name --verbose not found.");
        }

        [Test]
        public void ArgParser_GetArgAsString_ArgExisted_retValue()
        {
            ArgParser.SetArgs("--Name", "Ivan");
            Assert.That(ArgParser.GetArgAsString("--Name"), Is.EqualTo("Ivan"));
        }

        [Test]
        public void ArgParser_GetArgAsString_ArgNotExisted_retNull()
        {
            ArgParser.SetArgs("--Name", "Ivan");
            Assert.That(ArgParser.GetArgAsString("--Version"), Is.Null);
        }
    }
}