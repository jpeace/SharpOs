using Machine.Cpu.Execution.Instructions;

namespace Machine.Cpu.Execution
{
    public interface ICpuInstructionHandler
    {
        CpuOpCodes OpCodeHandled { get; }
        void Handle(ICpu cpu, CpuInstruction instruction);
    }
}