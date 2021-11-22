using System.Collections;
using System.Text;

namespace OpList.ConsoleApp
{
    internal class OpList<T> : IEnumerable<T>
    {
        private OpElement<T> _first;
        private int _idx;
        public int Count { 
            get
            {
                int length = 0;
                OpElement<T> current = _first;

                do
                {
                    length++;
                    current = current.Next;
                }
                while (current != _first);

                return length;
            } 
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public OpList()
        {
            _first = new OpElement<T>();
            _idx = -1;
        }
        public OpList(T value)
        {
            _first = new OpElement<T>(value);
            _idx = -1;
        }
        public OpList(OpElement<T> first)
        {
            _first = first;
        }

        public void Add(T value)
        {
            var previous = _first.Previous;

            var newElement = new OpElement<T>(value, previous, _first);
            previous.Next = newElement;
            _first.Previous = newElement;
        }

        public void Add(int i, T value)
        {
            OpElement<T> previous = _first.Previous;
            OpElement<T> current = _first;
            OpElement<T> next = _first;

            var op = ReadMode(i);

            var j = 0;

            while (j != i)
            {
                if (op == 1)
                {

                    current = current.Next;
                    next = current;
                    previous = current.Previous;

                    j += op;

                    current = new OpElement<T>(value, previous, next);
                    previous.Next = current;
                    next.Previous = current;
                }

                else
                {
                    current = current.Previous;
                    next = current;
                    previous = current.Next;

                    j += op;

                    current = new OpElement<T>(value, next, previous);
                    previous.Previous = current;
                    next.Next = current;
                }
            }

        }

        public void AddRange(OpList<T> range)
        {

        }

        public OpElement<T> IndexOf(int i)
        {
            OpElement<T> current = _first;

            var op = ReadMode(i);

            var j = 0;

            while (j != i)
            {
                current = op == 1 ? current.Next : current.Previous;

                j += op;
            }

            return current;
        }

        public void Replace(int i, T value)
        {
            OpElement<T> previous = _first.Previous;
            OpElement<T> current = _first;
            OpElement<T> next = _first;

            var op = ReadMode(i);

            var j = 0;

            if (op == 1)
            {

                while (j != i)
                {
                    current = current.Next;
                    next = current.Next;
                    previous = current.Previous;

                    j += op;
                }

                current = new OpElement<T>(value, previous, next);
                previous.Next = current;
                next.Previous = current;
            }

            else
            {
                while (j != i)
                {
                    current = current.Previous;
                    next = current.Previous;
                    previous = current.Next;

                    j += op;
                }

                current = new OpElement<T>(value, next, previous);
                previous.Previous = current;
                next.Next = current;
            }
        }

        public void Remove(int i)
        {
            OpElement<T> current = IndexOf(i);
            OpElement<T> previous = current.Previous;
            OpElement<T> next = current.Next;

            if(i == 0 || -(Count) == i)
            {
                _first = next;
            }

            previous.Next = next;
            next.Previous = previous;
        }

        public T this[int i]
        {
            get { return IndexOf(i).Value; }
            set { Replace(i, value); }
        }

        public override string ToString()
        {
            Console.WriteLine("Mo te lo scrivo subito");
            StringBuilder listToString = new StringBuilder();
            OpElement<T> current = _first;

            do
            {
                listToString.Append(current.Value.ToString() + ", ");
                current = current.Next;
            }
            while(current != _first);

            return listToString.ToString();
        }

        private int ReadMode(int i) => i < 0 ? -1 : 1;

        public IEnumerator<T> GetEnumerator() => new OpElementEnum<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
