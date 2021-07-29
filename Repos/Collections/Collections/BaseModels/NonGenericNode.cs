namespace Collections.BaseModels
{
    public class NonGenericNode
    {
        public NonGenericNode(object val)
        {
            Value = val;
        }
        public object Value { get; set; }
        public NonGenericNode Next { get; set; }
    }
}