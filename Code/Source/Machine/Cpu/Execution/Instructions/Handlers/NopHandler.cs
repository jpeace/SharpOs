using System.Diagnostics;

namespace Machine.Cpu.Execution.Instructions.Handlers
{
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
}