namespace Machine.Cpu.Execution.Instructions.Handlers
{
    public class IntHandler : ICpuInstructionHandler
    {
        public CpuOpCodes OpCodeHandled
        {
            get { return CpuOpCodes.Int; }
        }

        public void Handle(ICpu cpu, CpuInstruction instruction)
        {
            cpu.Interrupt((byte)instruction.SingleOperand);
            cpu.IP.Increment(CpuInstruction.Width);
        }
    }
}