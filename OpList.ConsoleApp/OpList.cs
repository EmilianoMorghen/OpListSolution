using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public bool IsReadOnly => false;

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
            OpElement<T> current = IndexOf(i);
            OpElement<T> previous = current.Previous;
            OpElement<T> next = current;

            current = new OpElement<T>(value, previous, next);
            previous.Next = current;
            next.Previous = current;
        }

        public void AddRange(OpList<T> range)
        {

        }

        public OpElement<T> IndexOf(int requestedIndex)
        {
            OpElement<T> currentNode = _first;

            var indexOperation = new IndexOperation(requestedIndex);

            for (var j = 0; j != indexOperation.Cycles; j++)
            {
                currentNode = indexOperation.NextNodeFunc(currentNode);
            }

            return currentNode;
        }
        public class IndexOperation
        {
            public int Cycles { get; }
            public Func<OpElement<T>, OpElement<T>> NextNodeFunc { get; }

            public IndexOperation(int requestedIndex)
            {
                var cyclingMode = ReadMode(requestedIndex);
                NextNodeFunc = x => 
                    cyclingMode == ModeEnum.Forward 
                        ? x.Next 
                        : x.Previous;

                var requestedIndexModule = Math.Abs(requestedIndex);
                Cycles = cyclingMode == ModeEnum.Forward 
                    ? requestedIndexModule -1 
                    : requestedIndexModule;
            }
            private ModeEnum ReadMode(int i) => i >= 0 ? ModeEnum.Forward : ModeEnum.Backward;
        }

        public void Replace(int i, T value)
        {
            IndexOf(i).Value = value;
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
            get => IndexOf(i).Value;
            set => Replace(i, value);
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

        public IEnumerator<T> GetEnumerator() => new OpElementEnum<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    internal enum ModeEnum
    {
        Forward,
        Backward
    }
}
