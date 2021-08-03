using System;
using System.Runtime.CompilerServices;

namespace Delegates
{
    public class Events
    {
        public void Run()
        {
            BarBrawler brawler = new BarBrawler();
            brawler.WasBeat += DisplayMessage;
            brawler.WasDrunk += DisplayEmptyMessage;
            brawler.WasDrunk += ()=> { int i = 1; /* имитация работы*/ };

            brawler.GenericHandler += (sender, args) => Console.WriteLine("Конец");
            brawler.Run();


        }
        private static void DisplayMessage(object sender, BrawlerEventArgs e)
        {
            Console.WriteLine("Внешний обработчик говорит:");
            Console.WriteLine($"Жизней: {e.HP}, выпито: {e.BeerCount}");
            Console.WriteLine();

        }
        private static void DisplayEmptyMessage()
        {
            Console.WriteLine("Внешний обработчик говорит:");
            Console.WriteLine("Напился и все это видят...");
            Console.WriteLine();

        }

    }



    public class BarBrawler
    {
        public delegate void BrawlerDelegate(object obj, BrawlerEventArgs e);
        public delegate void BrawlerEmptyDelegate();
        public EventHandler<BrawlerEventArgs> GenericHandler;

        public event BrawlerEmptyDelegate WasDrunk;
        private event BrawlerDelegate _wasBeat;

        public event BrawlerDelegate WasBeat
        {
            add
            {
                _wasBeat += value;
            }
            remove
            {
                _wasBeat -= value;

            }
        }

        Random _random = new Random();

        public int HP { get; set; } = 100;

        public int BeerCount { get; set; } = 0;

        public BarBrawler()
        {

        }

        public void Run()
        {
            bool wasCanceledFromBar = false;
            while (!wasCanceledFromBar)
            {
                Console.WriteLine("Бугай пьет пиво");
                Console.WriteLine("Пиво пить - здоровью вредить");
                HP -= 20;
                BeerCount++;

                if (_random.Next(0, 10) % 2 == 0)
                {
                    Console.WriteLine("Бугай пошел драться");

                    HP -= _random.Next(0, 20);
                    _wasBeat?.Invoke(this, new BrawlerEventArgs(HP, BeerCount));
                }
                if (BeerCount > 3)
                {
                    Console.WriteLine("Бугай напился");
                    HP -= _random.Next(20, 40);
                    WasDrunk?.Invoke();
                }
                if (HP <= 20)
                {
                    Console.WriteLine("Бугай был выгнан из бара");
                    wasCanceledFromBar = true;
                }
            }
            GenericHandler?.Invoke(this, new BrawlerEventArgs(HP, BeerCount));
        }


    }
    public class BrawlerEventArgs : EventArgs
    {
        public BrawlerEventArgs(int hp, int beerCount)
        {
            HP = hp;
            BeerCount = beerCount;
        }

        public int HP { get; set; }

        public int BeerCount { get; set; }
    }
}