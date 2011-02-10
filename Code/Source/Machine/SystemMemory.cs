namespace Machine
{
    public interface IMemory
    {
        Word MemorySize { get; }
        byte this[Word index] { get; set; }
    }

    public class SystemMemory : IMemory
    {
        private readonly Word _memorySize;

        private byte[] _space;

        public SystemMemory(Word memorySize)
        {
            _memorySize = memorySize;
            InitializeSpace();
        }

        public Word MemorySize { get { return _memorySize; } }

        public byte this [Word index]
        {
            get
            {
                ValidateMemoryAccess(index);
                return _space[index];
            }
            set
            {
                ValidateMemoryAccess(index);
                _space[index] = value;
            }
        }
        
        private void InitializeSpace()
        {
            _space = new byte[_memorySize];
        }

        private void ValidateMemoryAccess(Word index)
        {
            if (index >= _memorySize)
            {
                throw new MemoryAccessException();
            }
        }
    }
}