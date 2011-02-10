using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Machine.Cpu
{
    public interface ICpuInstructionExecutor
    {
        ICpu Cpu { set; }
        void Execute(CpuInstruction instruction);
    }

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

    public interface ICpuInstructionHandler
    {
        CpuOpCodes OpCodeHandled { get; }
        void Handle(ICpu cpu, CpuInstruction instruction);
    }

    public class NopHandler : ICpuInstructionHandler
    {
        public CpuOpCodes OpCodeHandled
        {
            get { return CpuOpCodes.Nop; }
        }

        public void Handle(ICpu cpu, CpuInstruction instruction)
        {
            Debug.WriteLine("In NOP");
            cpu.IP.Increment(CpuInstruction.Width);
        }
    }

    public class JmpAbsHandler : ICpuInstructionHandler
    {
        public CpuOpCodes OpCodeHandled
        {
            get { return CpuOpCodes.JmpAbs; }
        }

        public void Handle(ICpu cpu, CpuInstruction instruction)
        {
            Debug.WriteLine("In JMP");
            cpu.IP.Store(instruction.SingleOperand);
        }
    }
}