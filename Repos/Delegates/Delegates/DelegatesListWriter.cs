using System;

namespace Delegates
{
    public class DelegatesListWriter
    {
        delegate string MyDelegate(int val);

        static void DelegateInfo(Delegate dDelegate)
        {
            foreach (var method in dDelegate.GetInvocationList())
            {
                Console.WriteLine();

                Console.WriteLine($"Method:{method.Method}");
                Console.WriteLine($"Target:{method.Target}");

            }
        }
        public void Run()
        {
            var implementor = new DelegateImplementor();

            MyDelegate myDelegate = DelegateImplementor.PrinterWithAdd;
            myDelegate += implementor.PrinterAsIs;

            myDelegate(1);

            DelegateInfo(myDelegate);
        }

    }

    public class DelegateImplementor
    {
        public static string PrinterWithAdd(int val)
        {
            Console.WriteLine((val + 1).ToString());
            return (val + 1).ToString();
        }

        public string PrinterAsIs(int val)
        {
            Console.WriteLine((val).ToString());
            return (val).ToString();
        }
    }
}