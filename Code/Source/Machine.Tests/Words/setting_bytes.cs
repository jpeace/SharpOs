using Machine.Memory;
using NUnit.Framework;

namespace Machine.Tests.Words
{
    [TestFixture]
    public class setting_bytes
    {
        private Word _cut;

        [SetUp]
        public void Setup()
        {
            _cut = 0x12345678;
        }

        [Test]
        public void high_byte_is_properly_set()
        {
            _cut.HighByte = 0xab;
            _cut.ShouldEqual(((Word)0xab345678));
        }

        [Test]
        public void low_byte_is_properly_set()
        {
            _cut.LowByte = 0xab;
            _cut.ShouldEqual((Word)0x123456ab);
        }

        [Test]
        public void arbitrary_bytes_are_properly_set()
        {
            _cut.SetByte(0, 0xab).ShouldEqual((Word)0xab345678);
            _cut.SetByte(1, 0xcd).ShouldEqual((Word)0xabcd5678);
            _cut.SetByte(2, 0xef).ShouldEqual((Word)0xabcdef78);
            _cut.SetByte(3, 0x00).ShouldEqual((Word)0xabcdef00);
        }

        [Test]
        public void byte_spans_are_properly_set()
        {
            _cut.SetByteSpan(-1, 4, 0xabcd).ShouldEqual((Word)0x12345678);
            _cut.SetByteSpan(2, 1, 0xabcd).ShouldEqual((Word)0x12345678);
            _cut.SetByteSpan(2, 2, 0xab).ShouldEqual((Word)0x1234ab78);
            _cut.SetByteSpan(1, 2, 0xabcd).ShouldEqual((Word)0x12abcd78);
        }

        [Test]
        public void index_out_of_range_has_no_effect()
        {
            _cut.SetByte(-1, 0xab).ShouldEqual((Word)0x12345678);
            _cut.SetByte(4, 0xab).ShouldEqual((Word)0x12345678);
        }
    }
}