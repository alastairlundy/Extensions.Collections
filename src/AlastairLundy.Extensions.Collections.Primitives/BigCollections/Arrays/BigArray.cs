/*
        MIT License
       
       Copyright (c) 2024-2025 Alastair Lundy
       
       Permission is hereby granted, free of charge, to any person obtaining a copy
       of this software and associated documentation files (the "Software"), to deal
       in the Software without restriction, including without limitation the rights
       to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
       copies of the Software, and to permit persons to whom the Software is
       furnished to do so, subject to the following conditions:
       
       The above copyright notice and this permission notice shall be included in all
       copies or substantial portions of the Software.
       
       THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
       IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
       FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
       AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
       LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
       OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
       SOFTWARE.
   */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using AlastairLundy.Extensions.Collections.Primitives.Generics;

namespace AlastairLundy.Extensions.Collections.Primitives.BigCollections
{
    public class BigArray<T> : IEnumerable<T>
    {
        private readonly long _length;
        private readonly bool _isFixedSize;
        private readonly bool _isReadOnly;

        private readonly long _rank;

        private readonly int _currentArrayList;
    
        private readonly List<GenericArrayList<T>> _items;
    
        public BigArray()
        {
            _length = 0;
            _currentArrayList = 0;
            _isFixedSize = false;
            _items = new List<GenericArrayList<T>>();
        }

        public BigArray(IEnumerable<T> source)
        {
            _length = 0;
            _isFixedSize = false;
            _items = new List<GenericArrayList<T>>();
        
            AddRange(source);
        }

        protected void AddRange(IEnumerable<T> source)
        {
            long sourceLength = source.LongCount();

            GenericArrayList<T> array = _items[_currentArrayList];
            _length = 
        }

        protected void AddRangeToArrayList(int arrayNumber, IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                _items[arrayNumber].Add(item);   
            }
        }
    
        public bool IsFixedSize => _isFixedSize;
        public bool IsReadOnly => _isReadOnly;
        public bool IsSynchronized { get; protected set; }

        public long Length => _length;

        public long MaxLength { get; } = long.MaxValue;

        public long Rank => _rank;

        public static BigReadOnlyCollection<T> AsReadOnly()
        {
            BigReadOnlyCollection<T> collection = new BigReadOnlyCollection<T>();
        
        
        }

        public static void Clear(BigArray<T> array)
        {
            array.Clear();
        }

        public static void Clear(BigArray<T> array, long index, long length)
        {
        
        }
    
        public void Clear()
        {
        
        }

        public object Clone()
        {
        
        }

        public static BigArray<T> Empty()
        {
            return new BigArray<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
        
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
        
        }
    }

    internal class BigArrayEnumerator<T> : IEnumerator<T>
    {
        private BigArray<T> _array;

        private long _position = -1;
    
        internal BigArrayEnumerator(BigArray<T> array)
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