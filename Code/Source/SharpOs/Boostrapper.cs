using Machine.Cpu.Execution.Instructions;
using Machine.Memory;

namespace SharpOs
{
    public static class Boostrapper
    {
        public static void Boot()
        {
            Machine.Machine.Boot(m =>
                                     {
                                         var nop = new CpuInstruction {OpCode = CpuOpCodes.Nop};
                                         var jmp = new CpuInstruction { OpCode = CpuOpCodes.JmpRel, SingleOperand = -Word.Width };

                                         m.Memory.SetWordAt(100, nop.Raw);
                                         m.Memory.SetWordAt(104, jmp.Raw);

                                         m.Cpu.IP.Store(100);
                                     });
        }
    }
}