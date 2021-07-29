using System.Collections.Generic;
using System.Linq;

namespace Collections.Extra
{
    public class BoreNode
    {
        public BoreNode()
        {
            ChildBoreNodes = new List<BoreNode>();
        }

        public char? Value { get; set; }
        public BoreNode ParentBoreNode { get; set; }
        public bool IsWordFinishedHere { get; set; }

        public List<BoreNode> ChildBoreNodes { get; set; }

        protected bool HasChildWithValue(char val)
            => ChildBoreNodes.Any(x => x.Value.Equals(val));

        protected BoreNode GetFirstChildWithValue(char val)
            => ChildBoreNodes.FirstOrDefault(x => x.Value.Equals(val));

        protected IEnumerable<BoreNode> GetAllChildWithValue(char val)
            => ChildBoreNodes.Where(x => x.Value.Equals(val)).ToList();

        public void AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                IsWordFinishedHere = true;
                return;
            }

            // Search child with next letter, there will be either 0 or 1 those
            // if no -> add 

            char nextChar = word.First();

            var childBoreNodesWithNextChar = GetFirstChildWithValue(nextChar);

            if (childBoreNodesWithNextChar == null)
            {
                ChildBoreNodes.Add(GetChildBoreNodeData(nextChar));
                childBoreNodesWithNextChar = GetFirstChildWithValue(nextChar);
            }

            childBoreNodesWithNextChar.AddWord(word.Substring(1));
        }

        private BoreNode GetChildBoreNodeData(char val) =>
            new BoreNode() { ParentBoreNode = this, Value = val };
    }

}