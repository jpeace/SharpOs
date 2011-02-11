using System;
using Machine.Cpu;
using Machine.Cpu.Execution;
using Machine.Cpu.Execution.Instructions.Handlers;
using Machine.Memory;

namespace Machine
{
    public interface IMachine
    {
        ICpu Cpu { get; }
        IMemory Memory { get; }
    }

    public class Machine : IMachine
    {
        private readonly ICpu _cpu;
        private readonly IMemory _memory;
        
        private Machine()
        {
            _memory = new SystemMemory(1024);

            var executor = new CpuInstructionExecutor();
            executor.AddHandler<NopHandler>();
            executor.AddHandler<JmpAbsHandler>();
            executor.AddHandler<JmpRelHandler>();
            executor.AddHandler<IntHandler>();

            _cpu = new BasicCpu(_memory, executor);
        }

        public ICpu Cpu { get { return _cpu; } }
        public IMemory Memory { get { return _memory; } }
        
        private void Start()
        {
            _cpu.Start();
        }
        
        public static void Boot(Action<IMachine> bootstrapper)
        {
            var m = new Machine();
            bootstrapper(m);
            m.Start();
        }
    }
}