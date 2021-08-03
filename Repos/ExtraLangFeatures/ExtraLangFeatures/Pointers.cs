using System.Collections;
using System.Collections.Generic;

namespace ExtraLangFeatures
{
    public class Pointers
    {
        public void Run()
        {
            var list = new UnsafeList(5);
        }
    }

    public unsafe class UnsafeList
    {
        private unsafe UnsafeNode* array;
        private int Size { get; set; }
        private int CurrentIndex { get; set; } = 0;

        public UnsafeList(int size)
        {
            Size = size;
        }

        public void Add(int val)
        {
            if (CurrentIndex == 0)
            {
                // Создаем новый массив
                CreateNewArray(Size);
            }
            else if (CurrentIndex == Size)
            {
                // Создаем новый массив и переносим туда имеющиеся данные
                Size *= 2;
                CreateNewArray(Size);
            }
            else
            {
                UnsafeNode node = new UnsafeNode() {Value = val, Next = null, Prev = null};
                array[CurrentIndex] = node;
            }
        }

        private void CreateNewArray(int size)
        {
            UnsafeNode* arrayInside = stackalloc UnsafeNode[size];
            array = arrayInside;
        }
    }
    public unsafe struct UnsafeNode
    {
        public int Value { get; set; }
        public int* Next { get; set; }
        public int* Prev { get; set; }

    }
}