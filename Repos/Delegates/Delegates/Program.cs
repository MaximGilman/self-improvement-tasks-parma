using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegatesListWriter delegateSHow = new DelegatesListWriter();
            delegateSHow.Run();
            Console.WriteLine("--------------------------");

            DelegateBrawler delegateBrawler = new DelegateBrawler();
            delegateBrawler.Run();
            Console.WriteLine("--------------------------");

            GenericDelegates genericDelegates = new GenericDelegates();
            genericDelegates.Run();
            Console.WriteLine("--------------------------");


            Events events = new Events();
            events.Run();
            Console.WriteLine("--------------------------");
        }
    }
}
