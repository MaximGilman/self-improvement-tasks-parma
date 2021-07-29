using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Collections
{
    public class MyQueue : BaseCollection
    {

        public MyQueue() : base()
        {
        }

        public MyQueue(int capacity) : base(capacity)
        {
        }


        private int _currentIndex = 0;

        /// <summary>
        /// Get
        /// </summary>
        public virtual object Dequeue()
        {
            var value = Peek();
            ResizeToLow();
            return value;
        }

        /// <summary>
        /// Add
        /// </summary>
        public virtual void Enqueue(object value)
        {
            Insert(_lastIndex, value);
            _lastIndex++;
        }

        public object Peek()
        {
            if (_lastIndex == 0) throw new IndexOutOfRangeException("Нет элементов");
            return _values[_currentIndex++];
        }

        protected void ResizeToLow()
        {
            if (_currentIndex <= Capacity / 2)
            {
                var newQueue = new object[Capacity / 2];
                int j = 0;
                for (int i = _currentIndex; i < _lastIndex; i++)
                {
                    newQueue[j++] = _values[i];
                }

                _values = newQueue;
                _currentIndex = 0;
                Capacity = _values.Length;
                _lastIndex = Capacity;
            }
            else
            if(Capacity ==1)
            {
                _values = Array.Empty<object>();
            }
        }
    }
}