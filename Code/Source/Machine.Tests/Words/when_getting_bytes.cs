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

        [Test]
        public void arbitrary_bytes_are_properly_evaluated()
        {
            _word.GetByte(0).ShouldEqual(0x12);
            _word.GetByte(1).ShouldEqual(0x34);
            _word.GetByte(2).ShouldEqual(0x56);
            _word.GetByte(3).ShouldEqual(0x78);
        }
    }
}