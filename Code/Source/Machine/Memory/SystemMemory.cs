using Machine.Memory.Exceptions;

namespace Machine.Memory
{
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

        public Word GetWordAt(Word location)
        {
            var ret = new Word();
            for (var i = 0 ; i < Word.Width ; ++i)
            {
                ValidateMemoryAccess(location + i);
                ret.SetByte(i, _space[location + i]);
            }
            return ret;
        }

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