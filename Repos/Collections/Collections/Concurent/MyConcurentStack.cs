using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Collections.BaseModels;

namespace Collections.Concurent
{
    public class MyConcurrentStack<T> : IProducerConsumerCollection<T>
    {
        private int count;
        private volatile Node<T> _head;

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        int ICollection.Count => count;

        public bool IsSynchronized { get; }
        public object SyncRoot { get; }

        public void CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }


        public bool TryAdd(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = _head;
            if (Interlocked.CompareExchange(ref _head, newNode, newNode.Next) != newNode.Next)
                TryPushSlow(newNode, newNode);
            return true;
        }

        public bool TryTake(out T item)
        {
            Node<T> head = _head;
            //stack is empty
            if (head == null)
            {
                item = default(T);
                return false;
            }

            if (Interlocked.CompareExchange(ref _head, head.Next, head) == head)
            {
                item = head.Value;
                return true;
            }

            // Fall through to the slow path.
            return TryTakeSlow(out item);
        }


        private void TryPushSlow(Node<T> head, Node<T> tail)
        {
            do
            {
                tail.Next = head;
            } while (Interlocked.CompareExchange(
                ref _head, head, tail.Next) != tail.Next);
        }

        private bool TryTakeSlow(out T item)
        {
            Node<T> poppedNode;

            if (TryTakeSlow(1, out poppedNode) == 1)
            {
                item = poppedNode.Value;
                return true;
            }

            item = default(T);
            return false;
        }

        private int TryTakeSlow(int index, out Node<T> poppedHead)
        {

            Node<T> head;
            Node<T> next;
            while (true)
            {
                head = _head;

                if (head == null)
                {
                    poppedHead = null;
                    return 0;
                }

                next = head;
                int nodesCount = 1;
                for (; nodesCount < count && next.Next != null; nodesCount++)
                {
                    next = next.Next;
                }

                // Try to swap the new head.  If we succeed, break out of the loop.
                if (Interlocked.CompareExchange(ref _head, next.Next, head) == head)
                {
                    // Return the popped Node.
                    poppedHead = head;
                    return nodesCount;
                }
            }
        }
    }
}