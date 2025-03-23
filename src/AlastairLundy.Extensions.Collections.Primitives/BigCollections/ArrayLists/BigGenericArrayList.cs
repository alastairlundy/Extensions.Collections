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

using System.Collections;
using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.Primitives.BigCollections
{
    public class BigGenericArrayList<T> : IBigGenericArrayList<T>
    {
        private readonly BigArray<KeyValuePair<T, bool>> _items;
    
        private long _itemsToRemove;
    
        private const long DefaultInitialCapacity = 10;
    
        public long Count { get; protected set; }
        public bool IsReadOnly { get;  protected set;  }
    
        public bool IsFixedSize { get;  protected set;  }
        public bool IsSynchronized { get;  protected set;  }
        public long Capacity { get;  protected set; }

        public BigGenericArrayList()
        {
            _itemsToRemove = 0;
        
            _items = new BigArray<KeyValuePair<T, bool>>();
        }

        public BigGenericArrayList(long initialCapacity)
        {
            _itemsToRemove = 0;
        
            _items = new BigArray<KeyValuePair<T, bool>>(false, false, false, initialCapacity, []);
        }

        public BigGenericArrayList(bool isReadOnly, bool isFixedSize, bool isSynchronized, long initialCapacity,
            IEnumerable<T> source)
        {
            IsReadOnly = isReadOnly;
            IsFixedSize = isFixedSize;
            IsSynchronized = isSynchronized;

            _items = new BigArray<KeyValuePair<T, bool>>(isReadOnly, isFixedSize, isSynchronized, initialCapacity, source);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
        
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
        
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    foreach (KeyValuePair<T, bool> pair in _items)
                    {
                        if (pair.Key is not null && pair.Key.Equals(item))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<T, bool> pair in _items)
                {
                    if (pair.Key is not null && pair.Key.Equals(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Remove(T item)
        {
            if (_itemsToRemove > 10)
            {
            
            }
            else
            {
                long index = IndexOf(item);
            
                _items[index].Value = new KeyValuePair<T, bool>(item, false);
            
                _itemsToRemove++;
            }
        }
    

        public T this[long index]
        {
            get
            {
            
            }
            set
            {
            
            }
        }

        public long IndexOf(T item)
        {
        
        }

        public void Insert(long index, T item)
        {
        
        }

        public void RemoveAt(long index)
        {
        
        }


        public void AddRange(ICollection<T> collection)
        {
        
        }

        public long BinarySearch(long index, long count, T value, IComparer<T> comparer)
        {
        
        }

        public long BinarySearch(T value, IComparer<T> comparer)
        {
        
        }

        public void CopyTo(BigArray<T> array)
        {
        
        }

        public void CopyTo(long index, BigArray<T> array, long arrayIndex, long count)
        {
        
        }

        public IBigGenericArrayList<T> FixedSize(IBigGenericArrayList<T> source)
        {
        
        }

        public IBigList<T> FixedSize(IBigList<T> source)
        {
        
        }

        public IBigGenericArrayList<T> GetRange(long index, long count)
        {
        
        }

        public long IndexOf(T? value, long startIndex)
        {
        
        }

        public long IndexOf(T? value, long startIndex, long count)
        {
        
        }

        public void InsertRange(long index, ICollection<T> collection)
        {
        
        }

        public long LastIndexOf(T value)
        {
        
        }

        public long LastIndexOf(T value, long startIndex)
        {
        
        }

        public long LastIndexOf(T value, long startIndex, long count)
        {
        
        }

        public IBigGenericArrayList<T> ReadOnly(IBigGenericArrayList<T> source)
        {
            return new BigGenericArrayList<T>(true, source.IsFixedSize, source.IsSynchronized, source.Capacity, source);
        }

        public IList<T> ReadOnly(IList<T> source)
        {
        
        }

        public void RemoveRange(long index, long count)
        {
        
        }

        public IBigGenericArrayList<T> Repeat(T value, long count)
        {
        
        }

        public void Reverse()
        {
        
        }

        public void Reverse(long index, long count)
        {
        
        }

        public void SetRange(long index, ICollection<T> collection)
        {
        
        }

        public void Sort()
        {
        
        }

        public void Sort(IComparer<T> comparer)
        {
        
        }

        public void Sort(long index, long count, IComparer<T> comparer)
        {
        
        }

        public IBigGenericArrayList<T> Synchronized(IBigGenericArrayList<T> source)
        {
        
        }

        public IBigList<T> Synchronized(IBigList<T> source)
        {
        
        }

        public BigArray<T> ToArray()
        {
        
        }

        public void TrimToSize()
        {
        
        }
    }
}