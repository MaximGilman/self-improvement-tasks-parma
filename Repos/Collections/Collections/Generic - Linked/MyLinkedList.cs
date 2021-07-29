using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.CompilerServices;
using Collections.BaseModels;

namespace Collections
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        protected internal LinkedNode<T> head;
        protected internal LinkedNode<T> tail;
        protected internal int count;

        public MyLinkedList()
        {
        }

        /// <summary>
        /// Добавление в конец
        /// </summary>
        public  void Add(T data)
        {
            LinkedNode<T> node = new LinkedNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
            }

            tail = node;
            count++;
        }

        /// <summary>
        /// Добавление в начало
        /// </summary>
        public  void AddFirst(T data)
        {
            LinkedNode<T> node = new LinkedNode<T>(data) {Next = head};
            head.Prev = node;
            node.Next = head;
            
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        
        public  bool Remove(T data)
        {
            LinkedNode<T> current = head;
            LinkedNode<T> previous = null;

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