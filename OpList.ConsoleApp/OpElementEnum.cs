using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpList.ConsoleApp
{
    internal class OpElementEnum<T> : IEnumerator<T>
    {
        public T Current => OpList[_idx];

        object IEnumerator.Current => Current;

        public OpList<T> OpList { get; }

        private int _idx;

        public OpElementEnum(OpList<T> opList)
        {
            OpList = opList;
            _idx = -1;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++_idx < OpList.Count;
        }

        public void Reset()
        {
            _idx = -1;
        }
    }
}
