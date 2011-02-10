using Machine.Memory;

namespace Machine.Cpu
{
    public class CpuInstruction
    {
        private Word _raw;

        public CpuInstruction(){}
        public CpuInstruction(Word raw)
        {
            _raw = raw;
        }

        public Word Raw { get { return _raw; } }

        public CpuOpCodes OpCode
        {
            get { return (CpuOpCodes)_raw[0]; }
            set { _raw[0] = (byte) value; }
        }

        public int SingleOperand
        {
            get { return _raw.GetByteSpan(1, 3); }
            set { _raw.SetByteSpan(1, 3, value); }
        }

        public int LeftOperand
        {
            get { return _raw[1]; }
            set { _raw[1] = (byte)value; }
        }

        public int RightOperand
        {
            get { return _raw.GetByteSpan(2,3); }
            set { _raw.SetByteSpan(2, 3, value); }
        }
    }
}