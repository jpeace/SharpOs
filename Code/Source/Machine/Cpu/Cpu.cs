using Machine.Memory;

namespace Machine.Cpu
{
    public interface ICpu
    {
        Register AX { get; }
        Register BX { get; }
        Register CX { get; }
        Register DX { get; }

        Register SP { get; }
        Register IP { get; }

        void Start();
    }

    public class BasicCpu : ICpu
    {
        private readonly IMemory _memory;
        private readonly ICpuInstructionExecutor _instructionExector;

        private Register _ax;
        private Register _bx;
        private Register _cx;
        private Register _dx;

        private Register _sp;
        private Register _ip;

        public BasicCpu(IMemory memory, ICpuInstructionExecutor instructionExector)
        {
            SetupRegisters();

            _memory = memory;
            _instructionExector = instructionExector;

            _instructionExector.Cpu = this;
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

        public void Start()
        {
            while(true)
            {
                var instruction = new CpuInstruction(_memory.GetWordAt(IP));
                _instructionExector.Execute(instruction);
            }
        }
    }
}