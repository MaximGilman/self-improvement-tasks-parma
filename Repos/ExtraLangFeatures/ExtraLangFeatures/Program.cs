using System;

namespace ExtraLangFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationOverrider operationOverrider = new OperationOverrider();
            operationOverrider.Run();
            Console.WriteLine("---------------------");

            Console.WriteLine("строкабезпробелов".GetLettersCount());
            Console.WriteLine("строка без пробелов".GetLettersCount());

        }
    }
}
