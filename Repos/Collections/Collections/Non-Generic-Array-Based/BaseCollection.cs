using System;
using System.Collections;

namespace Collections
{
    public class BaseCollection: IEnumerable
    {
        public int Capacity { get; set; }

        
        protected object[] _values;
        protected int _lastIndex;
        public BaseCollection(int capacity)
        {
            Capacity = capacity;
            _values = new object[Capacity];
            _lastIndex = 0;
        }

        public BaseCollection()
        {
            _values = Array.Empty<object>();
            _lastIndex = 0;
            Capacity = 0;
        }

        protected void ResizeToHigh()
        {
            // Забьем на переполнение
            if (Capacity == 0) Capacity = 1;
            else Capacity *= 2;

            var newArr = new object[Capacity];
            for (int i = 0; i < _lastIndex; i++)
            {
                newArr[i] = _values[i];
            }

            _values = newArr;
        }

        protected void Insert(int index, object value)
        {
            if (_lastIndex >= Capacity)
            {
                ResizeToHigh();
            }
            _values[_lastIndex] = value;
        }
        public IEnumerator GetEnumerator()
        {
            return _values.GetEnumerator();
        }
        
    }
}