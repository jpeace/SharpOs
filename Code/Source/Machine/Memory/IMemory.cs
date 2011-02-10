namespace Machine.Memory
{
    public interface IMemory
    {
        Word MemorySize { get; }
        Word GetWordAt(Word location);
        byte this[Word index] { get; set; }
    }
}