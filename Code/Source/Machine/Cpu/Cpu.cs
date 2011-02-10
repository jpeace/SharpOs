using Machine.Memory;

namespace Machine.Cpu
{
    public interface ICpu
    {        
    }

    public class BasicCpu : ICpu
    {
        private IMemory _memory;

        private Register _ax;
        private Register _bx;
        private Register _cx;
        private Register _dx;

        private Register _sp;
        private Register _ip;

        public BasicCpu(IMemory memory)
        {
            SetupRegisters();

            _memory = memory;
        }

        public Register AX { get { return _ax; } }
        public Register BX { get { return _bx; } }
        public Register CX { get { return _cx; } }
        public Register DX { get { return _dx; } }

        public Register SP { get { return _sp; } }
        public Register IP { get { return _ip; } }

        private void SetupRegisters()
        {
            _ax = new Register();
            _bx = new Register();
            _cx = new Register();
            _dx = new Register();

            _sp = new Register();
            _ip = new Register();
        }
    }
}