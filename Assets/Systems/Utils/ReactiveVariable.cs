using System;
using UnityEngine.Events;

namespace Systems.Utils
{
    [Serializable]
    public class ReactiveVariable<T>
    {
        public UnityAction<T> OnValueChanged = delegate {};
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (_value == null)
                {
                    _value = value;
                }
                else if (!_value.Equals(value))
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
        }
        
        private readonly int _hashCode;

        public ReactiveVariable()
        {
            _hashCode = base.GetHashCode();
        }
        
        public static implicit operator T(ReactiveVariable<T> reactiveVariable)
        {
            return reactiveVariable.Value;
        }
        
        public static bool operator ==(ReactiveVariable<T> a, T b)
        {
            if (a is null) return false;
            return a.Value.Equals(b);
        }
        
        public static bool operator !=(ReactiveVariable<T> a, T b)
        {
            if (a is null) return true;
            return !a.Value.Equals(b);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is ReactiveVariable<T> other)
            {
                return this == other;
            }
            
            if (obj is T val)
            {
                return this == val;
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return _hashCode.GetHashCode();
        }
    }
}