namespace Machine.Cpu.Execution.Instructions.Handlers
{
    public class JmpRelHandler : ICpuInstructionHandler
    {
        public CpuOpCodes OpCodeHandled
        {
            get { return CpuOpCodes.JmpRel; }
        }

        public void Handle(ICpu cpu, CpuInstruction instruction)
        {
            cpu.IP.Increment(instruction.SingleOperand);
        }
    }
}