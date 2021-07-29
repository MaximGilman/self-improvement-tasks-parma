using System;
using System.Collections;
using System.Linq;
using Collections.Extra;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region non generic

            //   ArrayList

            ArrayList list = new ArrayList() { 1, "2", 12 };
            Console.WriteLine(nameof(list));
            list.Add("mynewStr");
            Show(nameof(list), list, list.Capacity);
            Console.WriteLine("-------------------------");

            ////////////////////////////////////////////////////////////////////////////////
            MyArrayList myArrayList = new MyArrayList() { 1, 2, 3 };
            ShowArrayList(myArrayList);

            MyArrayList myEmptyArrayList = new MyArrayList();
            ShowArrayList(myEmptyArrayList);

            MyArrayList myCapacityArrayList = new MyArrayList(3);
            ShowArrayList(myCapacityArrayList);

            ////////////////////////////////////////////////////////////////////////////////

            // Queue
            MyQueue queue = new MyQueue();
            queue.Enqueue("first");
            ShowQueue(queue);

            // Stack
            MyStack stack = new MyStack(5);
            Console.WriteLine("Insert first,second, third");

            stack.Push("first");
            stack.Push("second");
            stack.Push("third");

            Console.WriteLine("Read:");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            #endregion


            #region Generic

            MyList<string> myList = new MyList<string>() {"1", "2", "3"};
            
            myList.Add("4");
            myList.AddFirst("0");

            foreach (var element in myList)
            {
                    Console.WriteLine(element.ToString());
            }



            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            myLinkedList.Add(1);
            myLinkedList.Add(12);
            myLinkedList.AddFirst(123);

            foreach (var element in myList)
            {
                Console.WriteLine(element.ToString());
            }
            #endregion #endregion


            BoreNodeProgram.Run();
        }

        static void ShowArrayList(MyArrayList myArrayList)
        {
            Console.WriteLine($"Shows {nameof(myArrayList)}");
            Console.WriteLine($"Capacity {myArrayList.Capacity}");
            myArrayList.Add("123");
            Console.WriteLine($"Add 123");

            Console.WriteLine($"Capacity {myArrayList.Capacity}");

            Show(nameof(myArrayList), myArrayList, myArrayList.Capacity);

            Console.WriteLine("Update via index");
            myArrayList[0] = "hey i changed";
            Show(nameof(myArrayList), myArrayList, myArrayList.Capacity);

            Console.WriteLine("Clear");
            myArrayList.Clear();
            Show(nameof(myArrayList), myArrayList, myArrayList.Capacity);
            Console.WriteLine();
            Console.WriteLine("-------------------------");

        }

        static void ShowQueue(MyQueue myQueue)
        {
            Console.WriteLine($"Shows {nameof(myQueue)}");

            myQueue.Enqueue("Max");
            Show(nameof(myQueue), myQueue, myQueue.Capacity);
            Console.WriteLine($"Remove first");

            var first = myQueue.Dequeue();
            Show(nameof(myQueue), myQueue, myQueue.Capacity);
            Console.WriteLine();
            myQueue.Dequeue();
            // генерирует исключение
            //myQueue.Dequeue(); myQueue.Dequeue();
            Console.WriteLine("-------------------------");

        }

        static void Show(string name, IEnumerable collection, int capacity)
        {
            Console.WriteLine($"Print {name} collection:");
            if (capacity == 0) Console.WriteLine("Empty");
            else
                foreach (var element in collection)
                {
                    Console.WriteLine(element?.ToString() ?? "null");
                }
        }
    }
}
