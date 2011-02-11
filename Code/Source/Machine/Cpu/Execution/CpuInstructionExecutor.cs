using System.Collections.Generic;
using Machine.Cpu.Execution.Instructions;

namespace Machine.Cpu.Execution
{
    class CpuInstructionExecutor : ICpuInstructionExecutor
    {
        private ICpu _cpu;
        private readonly IList<ICpuInstructionHandler> _handlers;
        private readonly IDictionary<CpuOpCodes, ICpuInstructionHandler> _handlerCache;

        public CpuInstructionExecutor()
        {
            _handlers = new List<ICpuInstructionHandler>();
            _handlerCache = new Dictionary<CpuOpCodes, ICpuInstructionHandler>();
        }

        public ICpu Cpu
        {
            set { _cpu = value; }
        }

        public void Execute(CpuInstruction instruction)
        {
            if (!_handlerCache.ContainsKey(instruction.OpCode))
            {
                foreach (var h in _handlers)
                {
                    if (h.OpCodeHandled == instruction.OpCode)
                    {
                        _handlerCache.Add(instruction.OpCode, h);
                        break;
                    }
                }
            }
            // TODO - Deal with unknown instructions
            _handlerCache[instruction.OpCode].Handle(_cpu, instruction);
        }

        public void AddHandler<T>() where T : ICpuInstructionHandler, new()
        {
            AddHandler(new T());
        }

        public void AddHandler(ICpuInstructionHandler handler)
        {
            _handlers.Add(handler);
        }
    }
}