using Machine.Cpu;
using Machine.Memory;

namespace Machine
{
    public class Machine
    {
        private ICpu _cpu;
        private readonly IMemory _memory;
        
        public Machine()
        {
            _memory = new SystemMemory(1024);

            var executor = new CpuInstructionExecutor();
            executor.AddHandler<NopHandler>();
            executor.AddHandler<JmpAbsHandler>();

            _cpu = new BasicCpu(_memory, executor);

            var nop = new CpuInstruction {OpCode = CpuOpCodes.Nop};
            var jmp = new CpuInstruction {OpCode = CpuOpCodes.JmpAbs, SingleOperand = 100};

            _memory.SetWordAt(100, nop.Raw);
            _memory.SetWordAt(104, jmp.Raw);

            _cpu.IP.Store(100);
        }

        public IMemory Memory { get { return _memory; } }
        public void Start()
        {
            _cpu.Start();
        }
    }
}