using System;

namespace Delegates
{
    public class GenericDelegates
    {
        delegate void Incrementor<T>(T argument);
        delegate T SuperIncrementor<T>(T argument);

         
        public void Run()
        {
            var myGenericIntDelegate = new Incrementor<int>(IntIncrementor);
            var myGenericStrDelegate = new Incrementor<string>(StringIncrementor);
            var myGenericDelegate = new Incrementor<long>(GenericIncrementor);
            
            myGenericIntDelegate.Invoke(1);
            myGenericStrDelegate.Invoke(1.ToString());
            myGenericDelegate.Invoke(1);

            var mySuperTypedDelegate = new SuperIncrementor<string>(SuperStringIncrementor);
            mySuperTypedDelegate.Invoke("22");

            Action<string> stringIncrementorAction = StringIncrementor;
            stringIncrementorAction("10");

            Func<string, string> genericLongFunc = SuperStringIncrementor;
            genericLongFunc("generic");

            Predicate<int> valueCheckerPredicate = i => i < 10;
            Console.WriteLine(valueCheckerPredicate.Invoke(10));

            valueCheckerPredicate += i => i % 2 == 0;
            Console.WriteLine(valueCheckerPredicate.Invoke(10));
            
        }

        public void StringIncrementor(string arg)
        {
            PrintType(arg);
            
            Console.WriteLine(arg+"1");
        }
        public void IntIncrementor(int arg)
        {
            PrintType(arg);

            Console.WriteLine(++arg);
        }

        public void GenericIncrementor<T>(T arg)
        {
            PrintType(arg);

            Console.WriteLine($"{arg}+1");
        }
        private void PrintType<T> (T arg) => Console.Write($"Type of: {arg.GetType().Name}      ");
        public string SuperStringIncrementor(string arg)
        {
            PrintType(arg);

            Console.WriteLine(arg + "1");
            return arg + "1";
        }
    }
}