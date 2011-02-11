using System.Diagnostics;

namespace Machine.Cpu.Execution.Instructions.Handlers
{
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