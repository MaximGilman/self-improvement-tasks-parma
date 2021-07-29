namespace Collections.BaseModels
{
    public class LinkedNode<T>
    {
        public LinkedNode(T val)
        {
            Value = val;
        }

        public LinkedNode<T> Prev { get; set; }
        public T Value { get; set; }
        public LinkedNode<T> Next { get; set; }
    }
}