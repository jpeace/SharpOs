using Machine.Memory;

namespace Machine.Cpu
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
    }
}