using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericHeap
{
    public class MinHeap<T> where T : IComparable<T>
    { 

        List<T> _allElements = new List<T>();

        public void Add( T toAdd)
        {
            _allElements.Add(toAdd);
            SiftUp();
        }

        public void Remove( T toRemove)
        {
            foreach(T el in _allElements)
            {
                if(el.CompareTo(toRemove) == 0)
                {
                    _allElements.Remove(toRemove);
                    SiftUp();
                    break;
                }
            }
        }

        public T Peek()
        {
            if (_allElements.Count > 0) return _allElements[0];
            return default(T);
        }

        public T Pop()
        {
            T toReturn = default(T);
            if (_allElements.Count > 0)
            {
                toReturn = _allElements[0];
                T lastElement = _allElements.TakeLast(1).Single();
                _allElements.Remove(toReturn);
                if (_allElements.Count > 1)
                {
                    _allElements[0] = lastElement;
                    if (lastElement.CompareTo(toReturn) > 0)
                        SiftUp();
                }
            }
            return toReturn;
        }

        private void SiftUp()
        {
            for(int i = 0; i < _allElements.Count / 2; i++)
            {
                T child, parent = _allElements[i];
                if (2 * i + 1 < _allElements.Count && _allElements[2 * i + 1].CompareTo(parent) < 0)
                {
                    child = _allElements[2 * i + 1];
                    _allElements[2 * i + 1] = parent;
                    _allElements[i] = child;
                    SiftUp();
                } else if(2 * i + 2 < _allElements.Count && _allElements[2 * i + 2].CompareTo(parent) < 0)
                {
                    child = _allElements[2 * i + 2];
                    _allElements[2 * i + 2] = parent;
                    _allElements[i] = child;
                    SiftUp();
                }
            }
        }
    }
}
