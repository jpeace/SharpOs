using Machine.Cpu;
using Machine.Memory;
using NUnit.Framework;

namespace Machine.Tests.Cpu
{
    [TestFixture]
    public class cpu_instruction_structure
    {
        private CpuInstruction _cut;

        [SetUp]
        public void Setup()
        {
            _cut = new CpuInstruction();    
        }

        [Test]
        public void op_code_is_stored_in_highest_byte()
        {
            _cut.OpCode = (CpuOpCodes)0x12;
            _cut.Raw.ShouldEqual((Word) 0x12000000);
        }

        [Test]
        public void single_operand_is_stored_in_lowest_bytes()
        {
            _cut.SingleOperand = 0x123456;
            _cut.Raw.ShouldEqual((Word) 0x00123456);
        }

        [Test]
        public void left_operand_is_stored_in_the_byte_immediately_after_operand()
        {
            _cut.LeftOperand = 0x12;
            _cut.Raw.ShouldEqual((Word) 0x00120000);
        }

        [Test]
        public void right_operand_is_stored_in_the_lowest_two_bytes()
        {
            _cut.RightOperand = 0x1234;
            _cut.Raw.ShouldEqual((Word) 0x00001234);
        }
    }
}