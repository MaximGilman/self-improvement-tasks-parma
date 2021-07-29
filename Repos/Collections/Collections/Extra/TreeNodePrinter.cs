using System;
using Collections.BaseModels;

namespace Collections.Extra
{
    public class BoreNodePrinter
    {
        // Constants for drawing lines and spaces
        private const string _cross = " ├─";
        private const string _corner = " └─";
        private const string _vertical = " │ ";
        private const string _space = "   ";

        public void Print(BoreNode rootBoreNode) =>
            PrintBoreNode(rootBoreNode, string.Empty);

        void PrintBoreNode(BoreNode BoreNode, string indent)
        {
            string isWordEndedFlag = BoreNode.IsWordFinishedHere ? "-" : string.Empty;
            Console.WriteLine($"{BoreNode.Value} {isWordEndedFlag}");

            // Loop through the children recursively, passing in the
            // indent, and the isLast parameter
            var numberOfChildren = BoreNode.ChildBoreNodes.Count;
            for (var i = 0; i < numberOfChildren; i++)
            {
                var child = BoreNode.ChildBoreNodes[i];
                var isLast = (i == (numberOfChildren - 1));
                PrintChildBoreNode(child, indent, isLast);
            }
        }

        void PrintChildBoreNode(BoreNode BoreNode, string indent, bool isLast)
        {
            // Print the provided pipes/spaces indent
            Console.Write(indent);

            // Depending if this BoreNode is a last child, print the
            // corner or cross, and calculate the indent that will
            // be passed to its children
            if (isLast)
            {
                Console.Write(_corner);
                indent += _space;
            }
            else
            {
                Console.Write(_cross);
                indent += _vertical;
            }

            PrintBoreNode(BoreNode, indent);
        }
    }

}