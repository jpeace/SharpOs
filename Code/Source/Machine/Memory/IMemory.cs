namespace Machine.Memory
{
    public interface IMemory
    {
        Word MemorySize { get; }
        Word GetWordAt(Word location);
        void SetWordAt(Word location, Word value);
        byte this[Word index] { get; set; }
    }
}