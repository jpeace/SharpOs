using NUnit.Framework;

namespace Machine.Tests.Words
{
    [TestFixture]
    public class when_getting_bytes
    {
        private readonly Word _word;

        public when_getting_bytes()
        {
            _word = 0x12345678;
        }

        [Test]
        public void high_byte_is_properly_evaluated()
        {
            _word.HighByte.ShouldEqual(0x12);
        }

        [Test]
        public void low_byte_is_properly_evaluated()
        {
            _word.LowByte.ShouldEqual(0x78);
        }
    }
}