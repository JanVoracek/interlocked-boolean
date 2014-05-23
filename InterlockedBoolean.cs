namespace CodingDojo
{
    public class InterlockedBoolean
    {
        private readonly bool _value;

        private static readonly InterlockedBoolean FalseValue = new InterlockedBoolean(false);
        private static readonly InterlockedBoolean TrueValue = new InterlockedBoolean(true);

        private InterlockedBoolean(bool value)
        {
            _value = value;
        }

        public static InterlockedBoolean Get(bool? value)
        {
            return value;
        }

        public static implicit operator bool(InterlockedBoolean interlockedBoolean)
        {
            return interlockedBoolean._value;
        }

        public static implicit operator InterlockedBoolean(bool value)
        {
            return value ? TrueValue : FalseValue;
        }

        public static InterlockedBoolean operator !(InterlockedBoolean b)
        {
            return !b._value;
        }

        public static InterlockedBoolean operator &(InterlockedBoolean a, InterlockedBoolean b)
        {
            return a._value && b._value;
        }

        public static bool operator false(InterlockedBoolean a)
        {
            return !a._value;
        }

        public static bool operator true(InterlockedBoolean a)
        {
            return a._value;
        }

        public static InterlockedBoolean operator |(InterlockedBoolean a, InterlockedBoolean b)
        {
            return a._value || b._value;
        }

        public static InterlockedBoolean operator ^(InterlockedBoolean a, InterlockedBoolean b)
        {
            return a._value ^ b._value;
        }

        public static InterlockedBoolean operator ==(InterlockedBoolean a, InterlockedBoolean b)
        {
            if ((object)a == null && (object)b == null) return true;
            if ((object)a == null || (object)b == null) return false;
            return a._value == b._value;
        }

        public static InterlockedBoolean operator !=(InterlockedBoolean a, InterlockedBoolean b)
        {
            return !(a == b);
        }

        public static InterlockedBoolean operator ==(InterlockedBoolean a, bool b)
        {
            if ((object)a == null) return false;
            return a._value == b;
        }

        public static InterlockedBoolean operator !=(InterlockedBoolean a, bool b)
        {
            return !(a == b);
        }

        public static InterlockedBoolean operator ==(bool a, InterlockedBoolean b)
        {
            if ((object)b == null) return false;
            return a == b._value;
        }

        public static InterlockedBoolean operator !=(bool a, InterlockedBoolean b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is InterlockedBoolean) return _value == (obj as InterlockedBoolean)._value;
            return _value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}