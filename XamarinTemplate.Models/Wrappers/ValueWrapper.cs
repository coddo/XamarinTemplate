namespace XamarinTemplate.Models.Wrappers
{
    public class ValueWrapper<T>
    {
        public ValueWrapper(T value)
        {
            Value = value;
        } 

        public T Value { get; set; }
    }
}
