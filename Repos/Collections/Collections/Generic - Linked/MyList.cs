using System.Collections;
using System.Collections.Generic;
using Collections.BaseModels;

namespace Collections
{
    public class MyList<T> : IEnumerable<T>
    {
        protected internal Node<T> head;
        protected internal Node<T> tail;
        protected internal int count;

        public MyList()
        {
        }
        /// <summary>
        /// Добавление в конец
        /// </summary>
        public virtual void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        /// <summary>
        /// Добавление в начало
        /// </summary>
        public virtual void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        public virtual bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(data))
                {
                    if (previous == null)
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}