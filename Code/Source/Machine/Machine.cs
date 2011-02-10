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
            _cpu = new BasicCpu(_memory);
        }

        public IMemory Memory { get { return _memory; } }
    }
}