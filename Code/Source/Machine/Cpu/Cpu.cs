using System;
using System.Collections.Generic;
using Machine.Cpu.Execution;
using Machine.Cpu.Execution.Instructions;
using Machine.Memory;

namespace Machine.Cpu
{
    public class BasicCpu : ICpu
    {
        private readonly IMemory _memory;
        private readonly IDictionary<byte, Action> _interruptTable;
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

            _interruptTable = new Dictionary<byte, Action>();
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

        public Action Interrupt(byte vectorEntry)
        {
            if (!_interruptTable.ContainsKey(vectorEntry) || _interruptTable[vectorEntry] == null)
            {
                return () => { };
            }
            return _interruptTable[vectorEntry];
        }

        public void HookInterrupt(byte vectorEntry, Action handler)
        {
            _interruptTable.Remove(vectorEntry);
            _interruptTable.Add(vectorEntry, handler);
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