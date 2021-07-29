using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Collections
{
    public class MyStack : BaseCollection
    {
        
        public MyStack(int capacity) : base(capacity)
        {
        }


        private int _currentIndex = 0;

        /// <summary>
        /// Get
        /// </summary>
        public object Pop()
        {
            var value= _values[--_currentIndex];

            _values[_currentIndex] = null;
            return value;
        }

        /// <summary>
        /// Add
        /// </summary>
        public void Push(object value)
        {
            if (_currentIndex == _values.Length)
                throw new InvalidOperationException("Переполнение стека");
            _values[_currentIndex++] = value;
        }

        public object Peek()
        {
            if (_lastIndex == 0) throw new IndexOutOfRangeException("Нет элементов");
            return _values[_currentIndex - 1];
        }
     
    }
}