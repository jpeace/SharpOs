namespace Machine
{
    public class Register
    {
        private Word _value;

        public void Store(Word value)
        {
            _value = value;
        }

        public static implicit operator Word(Register r)
        {
            return r._value;
        }

        public static implicit operator Register(Word value)
        {
            return new Register {_value = value};
        }
    }
}