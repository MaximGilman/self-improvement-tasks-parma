using System;

namespace Collections.Extra
{
    public class BoreNodeProgram
    {
        private static readonly BoreNode _rootNode = new BoreNode() { Value = 'r' };
        private static readonly BoreNodePrinter _printer = new BoreNodePrinter();
        public static void Run()
        {
            var loopContinue = true;

            while (loopContinue)
            {
                Console.WriteLine("Enter word to add, \'show\' or \'exit\'");
                var input = Console.ReadLine();
                switch (input?.ToLower())
                {
                    case "exit":
                        loopContinue = false;
                        break;
                    case "show":
                        Draw();
                        break;
                    default:
                        AddWord(input);
                        break;
                }

                ;
            }
        }

        private static void AddWord(string input)
        {
            _rootNode.AddWord(input);
        }

        private static void Draw()
        {
            _printer.Print(_rootNode);
        }

    }
}