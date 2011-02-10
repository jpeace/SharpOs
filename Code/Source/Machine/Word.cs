namespace Machine
{
    public class Word
    {
        private int _value;
        public static implicit operator int(Word w)
        {
            return w._value;
        }
        public static implicit operator Word(int i)
        {
            return new Word {_value = i};
        }

        public byte HighByte
        {
            get { return (byte)(_value >> 24); }
        }

        public byte LowByte
        {
            get { return (byte)(_value & 0x000000FF); }
        }
    }
}