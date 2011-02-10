using System;

namespace Machine.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsTypeOf(this object obj, Type type)
        {
            return obj.GetType() == type;
        }

        public static bool IsTypeOf<T>(this object obj)
        {
            return obj.IsTypeOf(typeof (T));
        }
    }
}