using NUnit.Framework;

namespace Machine.Tests.Words
{
    [TestFixture]
    public class when_setting_bytes
    {
        private Word _word;

        [SetUp]
        public void Setup()
        {
            _word = 0x12345678;
        }

        [Test]
        public void high_byte_is_properly_set()
        {
            _word.HighByte = 0xab;
            _word.ShouldEqual((Word)0xab345678);
        }

        [Test]
        public void low_byte_is_properly_set()
        {
            _word.LowByte = 0xab;
            _word.ShouldEqual((Word)0x123456ab);
        }
    }
}