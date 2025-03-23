using System;
using System.Collections;
using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.Primitives.BigCollections
{
    public struct BigArrayEnumerator<T> : IEnumerator<T>
    {
        private BigArray<T> _array;

        private long _position = -1;
    
        public BigArrayEnumerator(BigArray<T> array)
        {
            _array = array;
        }
    
        public void Dispose()
        {
            _array.Clear();
        }

        public bool MoveNext()
        {
            _position++;
        
            return (_position < _array.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current
        {
            get
            {
                try
                {
                    return _array[_position];
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        object? IEnumerator.Current => Current;
    }
}