using System;

namespace Delegates
{
    public class DelegateBrawler
    {
        public void Run()
        {
            Console.WriteLine("Бугай заходит в бар");
            Brawler brawler = new Brawler();

            Console.WriteLine("В баре стоит охранник");
            //brawler.WorkWithBrawler(AnotherBrawler);

            brawler.WorkWithBrawler(SecurityMan);

            bool? isPushedOut = false;
            Console.WriteLine("Бугай заказывает пиво...");

            while (isPushedOut != null && !isPushedOut.Value)
            {

                isPushedOut = brawler.DrinkBeer();

            }

            Console.WriteLine("Бугай сидит у бара");

        }

        private bool SecurityMan(int hp)
        {
            switch (hp)
            {
                case 0:
                    Console.WriteLine("Охранник:        вышвырнул бугая");
                    return true;
                case 100:
                    Console.WriteLine("Охранник:        не обращает внимания на бугая");
                    break;
                default:
                    Console.WriteLine("Охранник:        поглядывает на побитого бугая");
                    break;
            }

            return false;
        }
        private bool AnotherBrawler(int hp)
        {
            switch (hp)
            {
                case 100:
                    Console.WriteLine("Другой бугай:      решает подраться");
                    break;
                default:
                    Console.WriteLine("Другой бугай:      дерется с первым");
                    break;
            }

            return false;
        }

    }

    public class Brawler
    {
        private int Hp { get; set; } = 100;
        private int BeerCount { get; set; } = 0;
        private int Angry { get; set; } = 0;
        private bool IsDrunk { get; set; }
        public bool? DrinkBeer()
        {
            if (IsDrunk)
            {
                Console.WriteLine("Бугай уже напился, больше ему не наливают");
                Hp = 0;
                Console.WriteLine($"HP:{Hp}, Beer:{BeerCount}, Angry:{Angry}/6, IsDrunk:{IsDrunk}");
                return _securityDelegate?.Invoke(Hp);
            }
            else
            {
                BeerCount++;
                Angry++;
                if (Angry > 3)
                {
                    Console.WriteLine("Бугай разозился и пошел драться. Это стоило ему 10 HP");

                    Hp -= 10;
                }

                if (BeerCount > 5)
                {
                    Console.WriteLine("Бугай допивает последнее пиво и чувствует, что напился");
                    IsDrunk = true;
                }
                else
                {
                    Console.WriteLine("Бугай  пьет свое пиво");

                }
            }
            Console.WriteLine($"HP:{Hp}, Beer:{BeerCount}, Angry:{Angry}/6, IsDrunk:{IsDrunk}");
            Console.WriteLine();
            return _securityDelegate?.Invoke(Hp);


        }
        public delegate bool BrawlerHandler(int hp);

        private BrawlerHandler _securityDelegate;

        public bool WorkWithBrawler(BrawlerHandler handler)
        {
            _securityDelegate += handler;
            return handler.Invoke(Hp);
        }
    }
}