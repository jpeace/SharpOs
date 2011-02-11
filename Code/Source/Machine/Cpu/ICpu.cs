using System;

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

        Action Interrupt(byte vectorEntry);
        void HookInterrupt(byte vectorEntry, Action handler);

        void Start();
    }
}