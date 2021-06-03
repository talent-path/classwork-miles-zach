using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericHeap
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        List<T> _elements = new List<T>();

        public void Add(T toAdd)
        {
            _elements.Add(toAdd);
            SiftDown();
        }

        public void Remove(T toRemove)
        {
            foreach(T el in _elements)
            {
                if(el.CompareTo(toRemove) == 0)
                {
                    _elements.Remove(toRemove);
                    SiftDown();
                    break;
                }
            }
        }

        public T Peek()
        {
            if (_elements.Count > 0) return _elements[0];
            return default(T);
        }

        public T Pop()
        {
            T toReturn = default(T);
            if (_elements.Count > 0)
            {
                toReturn = _elements[0];
                T lastElement = _elements.TakeLast(1).Single();
                _elements.Remove(toReturn);
                if (_elements.Count > 1)
                {
                    _elements[0] = lastElement;
                    if (lastElement.CompareTo(toReturn) < 0)
                        SiftDown();
                }
            }

            return toReturn;
        }

        private void SiftDown()
        {
            for(int i = 0; i < _elements.Count / 2; i++)
            {
                T child, parent = _elements[i];
                if(2 * i + 1 < _elements.Count
                    && _elements[2 * i + 1].CompareTo(parent) > 0)
                {
                    child = _elements[2 * i + 1];
                    _elements[2 * i + 1] = parent;
                    _elements[i] = child;
                    SiftDown();
                } else if(2 * i + 2 < _elements.Count
                    && _elements[2 * i + 2].CompareTo(parent) > 0)
                {
                    child = _elements[2 * i + 2];
                    _elements[2 * i + 2] = parent;
                    _elements[i] = child;
                    SiftDown();
                }
            }
        }
    }
}
