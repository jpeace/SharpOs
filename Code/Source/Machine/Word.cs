namespace Machine
{
    public class Word
    {
        private uint _value;
        public static implicit operator uint(Word w)
        {
            return w._value;
        }
        public static implicit operator Word(uint i)
        {
            return new Word {_value = i};
        }

        public byte HighByte
        {
            get { return GetByte(0); }
            set 
            { 
                _value &= 0x00FFFFFF;
                _value |= (uint)(value << 24);
            }
        }

        public byte LowByte
        {
            get { return GetByte(3); }
            set 
            { 
                _value &= 0xFFFFFF00;
                _value |= value;
            }
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

        #region Equality

        public override bool Equals(object obj)
        {
            if (obj as Word == null)
            {
                return false;
            }
            return Equals((Word)obj);
        }

        public bool Equals(Word other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
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