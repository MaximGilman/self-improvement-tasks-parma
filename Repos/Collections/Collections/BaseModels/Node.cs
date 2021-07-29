namespace Collections.BaseModels
{
    public class Node<T>
    {
        public Node(T val)
        {
            Value = val;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}