using Machine.Extensions;

namespace Machine.Memory
{
    public struct Word
    {
        public const int Width = 4;

        private uint _value;

        #region Casts

        public static implicit operator uint(Word w)
        {
            return w._value;
        }
        public static implicit operator Word(uint i)
        {
            return new Word {_value = i};
        }
        public static implicit operator int(Word w)
        {
            return (int)w._value;
        }
        public static implicit operator Word(int i)
        {
            return new Word {_value = (uint)i};
        }

        #endregion

        #region Byte Manipulation

        public byte HighByte
        {
            get { return GetByte(0); }
            set { SetByte(0, value); }
        }

        public byte LowByte
        {
            get { return GetByte(3); }
            set { SetByte(3, value); }
        }

        public byte GetByte(int index)
        {
            if (index < 0 || index >= 4)
            {
                return 0;
            }
            var tmp = _value >> (24 - (index*8));
            return (byte)(tmp & 0xFF);
        }

        public Word SetByte(int index, byte value)
        {
            if (index >= 0 && index < 4)
            {
                uint mask = 0;
                for (var i = 0 ; i < 4 ; ++i)
                {
                    if (i != index)
                    {
                        mask |= (uint)(0xFF << (24 - 8*i));
                    }
                }
                _value &= mask;
                _value |= (uint)(value << (24 - 8*index));
            }

            return this;
        }

        public int GetByteSpan(int start, int end)
        {
            if (start < 0 || end >= 4 || start > end)
            {
                return 0;
            }

            int ret = 0;
            for (var i = start; i <= end; ++i)
            {
                ret |= (GetByte(i) << (8 * (end - i)));
            }
            return ret;
        }

        public Word SetByteSpan(int start, int end, int value)
        {
            if (start >= 0 && end < 4 && start <= end)
            {
                var w = (Word)value;
                for (var i = start; i <= end; ++i)
                {
                    SetByte(i, w[3 - (end - i)]);
                }
            }

            return this;
        }

        public byte this[int index]
        {
            get { return GetByte(index); }
            set { SetByte(index, value); }
        }

        #endregion

        #region Equality

        public override bool Equals(object obj)
        {
            bool compatible = obj.IsTypeOf<int>() || obj.IsTypeOf<uint>() || obj.IsTypeOf<Word>();
            return compatible && Equals((Word)obj);
        }

        public bool Equals(Word other)
        {
            return other._value == _value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return "0x" + _value.ToString("X");
        }

        #endregion
    }
}