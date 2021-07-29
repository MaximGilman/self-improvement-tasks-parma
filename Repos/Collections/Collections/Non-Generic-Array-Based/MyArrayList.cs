using System;
using System.Collections;

namespace Collections
{
    public class MyArrayList : BaseCollection
    {

        public MyArrayList() : base() { }

        public MyArrayList(int capacity) : base(capacity) { }



        public int Add(object value)
        {
            Insert(_lastIndex, value);
            _lastIndex++;
            return 1;
        }

        
       
        public void Clear()
        {
            _values = Array.Empty<object>();
            Capacity = 0;
        }
        public object this[int index]
        {
            get => index <= _lastIndex ? _values[index] : throw new IndexOutOfRangeException();
            set
            {
                if (index > _lastIndex) throw new IndexOutOfRangeException();
                this._values[index] = value;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        
        
    }
}