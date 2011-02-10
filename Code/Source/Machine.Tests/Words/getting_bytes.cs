using Machine.Memory;
using NUnit.Framework;

namespace Machine.Tests.Words
{
    [TestFixture]
    public class getting_bytes
    {
        private readonly Word _cut;

        public getting_bytes()
        {
            _cut = 0x12345678;
        }

        [Test]
        public void high_byte_is_properly_evaluated()
        {
            _cut.HighByte.ShouldEqual(0x12);
        }

        [Test]
        public void low_byte_is_properly_evaluated()
        {
            _cut.LowByte.ShouldEqual(0x78);
        }

        [Test]
        public void arbitrary_bytes_are_properly_evaluated()
        {
            _cut.GetByte(0).ShouldEqual(0x12);
            _cut.GetByte(1).ShouldEqual(0x34);
            _cut.GetByte(2).ShouldEqual(0x56);
            _cut.GetByte(3).ShouldEqual(0x78);
        }

        [Test]
        public void byte_spans_are_properly_evaluated()
        {
            _cut.GetByteSpan(-1, 4).ShouldEqual(0);
            _cut.GetByteSpan(2, 1).ShouldEqual(0);
            _cut.GetByteSpan(2, 2).ShouldEqual(0x56);
            _cut.GetByteSpan(1, 2).ShouldEqual(0x3456);
        }

        [Test]
        public void index_out_of_range_returns_zero()
        {
            _cut.GetByte(-1).ShouldEqual(0);
            _cut.GetByte(4).ShouldEqual(0);
        }
    }
}