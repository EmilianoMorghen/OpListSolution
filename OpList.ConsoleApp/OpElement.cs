using System.Collections;

namespace OpList.ConsoleApp
{
    internal class OpElement<T>
    {
        public T Value { get; set; }
        public OpElement<T> Next { get; set; }
        public OpElement<T> Previous { get; set; }

        public OpElement()
        {
            Value = default(T);
            Next = this;
            Previous = this;
        }
        
        public OpElement(T value)
        {
            Value = value;
            Previous = this;
            Next = this;
        }
        public OpElement(T value, OpElement<T> first)
        {
            Value = value;
            Previous = first;
            Next = first;
        }
        public OpElement(T value, OpElement<T> previous, OpElement<T> next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }
}