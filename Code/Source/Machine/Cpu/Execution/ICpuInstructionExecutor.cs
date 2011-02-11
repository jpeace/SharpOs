using Machine.Cpu.Execution.Instructions;

namespace Machine.Cpu.Execution
{
    public interface ICpuInstructionExecutor
    {
        ICpu Cpu { set; }
        void Execute(CpuInstruction instruction);
    }
}