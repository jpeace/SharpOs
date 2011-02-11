namespace Machine.Cpu.Execution.Instructions
{
    public enum CpuOpCodes
    {
        Nop = 0x1,
        JmpAbs = 0x2,
        JmpRel = 0x3,
        Int = 0x13
    }
}