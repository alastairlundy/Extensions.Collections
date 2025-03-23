﻿/*
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
using System.Diagnostics.Contracts;
using System.Linq;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable MergeIntoPattern

// ReSharper disable RedundantBoolCompare
// ReSharper disable MemberCanBePrivate.Global

namespace AlastairLundy.Extensions.Collections.Primitives.Generics
{
    /// <summary>
    /// Like an ArrayList, but uses generics.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericArrayList<T> : IGenericArrayList<T>
    {
        private readonly int _itemsToRemove;
    
        private const int DefaultInitialCapacity = 10;
        private KeyValuePair<T, bool>[] _items;

        private int _capacity;
        private int _count;
    
        private readonly bool _isReadOnly;
        private readonly bool _isFixedSize;
        
        protected GenericArrayList(bool isReadOnly, bool isFixedSize, bool isSynchronized, int capacity)
        {
            _capacity = capacity;
            _count = 0;
            _itemsToRemove = 0;
        
            _isReadOnly = isReadOnly;
            _isFixedSize = isFixedSize;
            IsSynchronized = isSynchronized;
            
            _items = new KeyValuePair<T, bool>[capacity];
        }
    
        protected GenericArrayList(bool isReadOnly, bool isFixedSize, bool isSynchronized, int capacity, ICollection<T> items)
        {
            _capacity = capacity;
            _count = 0;
            _itemsToRemove = 0;
        
            _isReadOnly = isReadOnly;
            _isFixedSize = isFixedSize;
            IsSynchronized = isSynchronized;

            _items = new KeyValuePair<T, bool>[capacity];
            
            AddRange(items);
        }
    
        /// <summary>
        /// 
        /// </summary>
        public GenericArrayList()
        {
            _items = new KeyValuePair<T, bool>[DefaultInitialCapacity];
            _capacity = DefaultInitialCapacity;
            _count = 0;
            _itemsToRemove = 0;
        
            _isReadOnly = false;
            _isFixedSize = false;
            IsSynchronized = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public GenericArrayList(ICollection<T> collection)
        {
            _items = new KeyValuePair<T, bool>[collection.Count + DefaultInitialCapacity];
            _capacity = collection.Count + DefaultInitialCapacity;
            _itemsToRemove = 0;
        
            _count = collection.Count;
            _isReadOnly = false;
            _isFixedSize = false;
            IsSynchronized = false;
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public GenericArrayList(int capacity)
        {
            _items = new KeyValuePair<T, bool>[capacity];
            _capacity = capacity;
            _itemsToRemove = 0;
            _count = 0;
        
            _isReadOnly = false;
            _isFixedSize = false;
            IsSynchronized = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isFixedSize"></param>
        public GenericArrayList(bool isFixedSize)
        {
            IsSynchronized = false;
            _isFixedSize = isFixedSize;
            _items = new KeyValuePair<T, bool>[DefaultInitialCapacity];
            _capacity = DefaultInitialCapacity;
            _itemsToRemove = 0;
            _count = 0;
        
            _isReadOnly = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new GenericArrayListEnumerator<T>(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIfResizeRequired()
        {
            if (_itemsToRemove >= 10)
            {
                TrimToSize();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (IsFixedSize)
            {
                return;
            }
        
            if (_capacity > Count)
            {
                _items[Count + 1] = new KeyValuePair<T, bool>(item, false);
                _count++;
            }
            else
            {
                KeyValuePair<T, bool>[] oldItems = new KeyValuePair<T, bool>[Count];
            
                KeyValuePair<T, bool>[] newItems = new KeyValuePair<T, bool>[Count + DefaultInitialCapacity];
            
                Array.Copy(_items, 0, oldItems, 0, Count);

                _items = newItems;
            
                _items[Count + 1] = new KeyValuePair<T, bool>(item, false);
                _count++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _items[i] = new KeyValuePair<T, bool>(_items[i].Key, true);
            }

            _capacity = DefaultInitialCapacity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            foreach (KeyValuePair<T, bool> t in _items)
            {
                if (t.Value == false && t.Key != null &&  t.Key.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            TrimToSize();

            if (arrayIndex < 0 || arrayIndex >= int.MaxValue)
            {
                throw new IndexOutOfRangeException();
            }
        
            Array.Copy(_items, arrayIndex, array, 0, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            try
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The number of items in the Generic Array List.
        /// </summary>
        public int Count => _count;
        
        /// <summary>
        /// 
        /// </summary>
        public int Capacity => _capacity;
    
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(ICollection<T> collection)
        {
            if (IsFixedSize)
            {
                return;
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    foreach (T item in collection)
                    {
                        Add(item);
                    }
                }
            }
            else
            {
                foreach (T item in collection)
                {
                    Add(item);
                }
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (IsFixedSize)
            {
                return;
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    foreach (T item in collection)
                    {
                        Add(item);
                    }
                }
            }
            else
            {
                foreach (T item in collection)
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int BinarySearch(int index, int count, T value, IComparer<T> comparer)
        {
            if (Count != Capacity)
            {
                TrimToSize();
            }
            
            Sort();

            if (index < 0 || index >= int.MaxValue || count < 0 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }

            return Array.BinarySearch(_items, index, count, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public int BinarySearch(T value, IComparer<T> comparer)
        {
            if (Count != Capacity)
            {
                TrimToSize();
            }
            
            Sort();

            return Array.BinarySearch(_items, value, (IComparer)comparer);
        }

        /// <summary>
        /// Performs a binary search on the Generic Array List.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The zero based index of the item if found; -1 otherwise.</returns>
        public int BinarySearch(T value)
        {
            return Array.BinarySearch(_items, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public void CopyTo(T[] array)
        {
            Array.Copy(_items, array, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <param name="count"></param>
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if (index > Count || index < 0 || count < 1 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }
            
            Array.Copy(_items, index, array, arrayIndex, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public IGenericArrayList<T> FixedSize(IGenericArrayList<T> source)
        {
            return new GenericArrayList<T>(source.IsReadOnly, true, source.IsSynchronized, source.Count, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public IList<T> FixedSize(IList<T> source)
        {
            return new GenericArrayList<T>(source.IsReadOnly, true, false, source.Count, source);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public IGenericArrayList<T> GetRange(int index, int count)
        {
            if (count > Count || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            GenericArrayList<T> list = new GenericArrayList<T>();

            int  limit = index + count;

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = index; i < limit; i++)
                    {
                        if (limit >= Count)
                        {
                            limit = Count;
                        }

                        if (_items[i].Value == true)
                        {
                            list.Add(_items[i].Key);
                        }
                        else
                        {
                            limit++;
                        }
                    }
                }
            }
            else
            {
                for (int i = index; i < limit; i++)
                {
                    if (limit >= Count)
                    {
                        limit = Count;
                    }
                
                    if (_items[i].Value == true)
                    {
                        list.Add(_items[i].Key);       
                    }
                    else
                    {
                        limit++;
                    }
                }
            }
            
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int IndexOf(T? value, int startIndex)
        {
            if (startIndex > Count || startIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int index = startIndex; index < Count; index++)
                    {
                        KeyValuePair<T, bool> pair = _items[index];
            
                        if (pair.Value == false && pair.Key is not null && pair.Key.Equals(value))
                        {
                            return index;
                        }
                    }
                }
            }
            else
            {
                for (int index = startIndex; index < Count; index++)
                {
                    KeyValuePair<T, bool> pair = _items[index];
            
                    if (pair.Value == false && pair.Key is not null && pair.Key.Equals(value))
                    {
                        return index;
                    }
                }
            }
        
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int IndexOf(T? value, int startIndex, int count)
        {
            int index = -1;
            
            if (startIndex > Count || startIndex < 0 || count < 1 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = startIndex; i < Count + count; i++)
                    {
                        T key = _items[i].Key;
                
                        if (key is not null && key.Equals(value))
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = startIndex; i < Count + count; i++)
                {
                    T key = _items[i].Key;
                
                    if (key is not null && key.Equals(value))
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        public void InsertRange(int index, ICollection<T> collection)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    foreach (T item in collection)
                    {
                        Insert(index, item);
                    }
                }
            }
            else
            {
                foreach (T item in collection)
                {
                    Insert(index, item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int LastIndexOf(T value)
        {
            return LastIndexOf(value, _items.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int LastIndexOf(T value, int startIndex)
        {
            int lastIndex = -1;
            
            if (startIndex > Count || startIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int index = startIndex; _items.Length > startIndex; index--)
                    {
                        KeyValuePair<T, bool> item = _items[index];

                        if (item.Value == false && item.Key != null && item.Key.Equals(value))
                        {
                            if (index > lastIndex)
                            {
                                lastIndex = index;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int index = startIndex; _items.Length > startIndex; index--)
                {
                    KeyValuePair<T, bool> item = _items[index];

                    if (item.Value == false && item.Key != null && item.Key.Equals(value))
                    {
                        if (index > lastIndex)
                        {
                            lastIndex = index;
                        }
                    }
                }   
            }

            return lastIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int LastIndexOf(T value, int startIndex, int count)
        {
            if (startIndex > Count || startIndex < 0 || count < 1 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }

            int limit = startIndex + Count + 1;

            int lastIndex = -1;

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = startIndex; i < limit; i++)
                    {
                        if (_items[i].Value == false && limit < Count)
                        {
                            limit++;
                        }
                        else if (limit >= Count)
                        {
                            limit = Count;
                        }
                        else if (i >= Count)
                        {
                            break;
                        }

                        if (_items[i].Value == true)
                        {
                            T key = _items[i].Key;
                    
                            if (key is not null && key.Equals(value))
                            {
                                lastIndex = i;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = startIndex; i < limit; i++)
                {
                    if (_items[i].Value == false && limit < Count)
                    {
                        limit++;
                    }
                    else if (limit >= Count)
                    {
                        limit = Count;
                    }
                    else if (i >= Count)
                    {
                        break;
                    }

                    if (_items[i].Value == true)
                    {
                        T key = _items[i].Key;
                    
                        if (key is not null && key.Equals(value))
                        {
                            lastIndex = i;
                        }
                    }
                }
            }
            
            return lastIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IGenericArrayList<T> ReadOnly(IGenericArrayList<T> source)
        {
            return new GenericArrayList<T>(true, source.IsFixedSize, source.IsSynchronized, source.Capacity, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IList<T> ReadOnly(IList<T> source)
        {
            bool isFixedSize;
            bool isSynchronized;

            if (source is T[] array)
            {
                isFixedSize = true;
                isSynchronized = array.IsSynchronized;
            }
            else
            {
                isFixedSize = true;
                isSynchronized = false;
            }
            
            return new GenericArrayList<T>(true, isFixedSize, isSynchronized, source.Count, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveRange(int index, int count)
        {
            if (index > Count || index < 0 || count < 1 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = 0; i < count; i++)
                    {
                        RemoveAt(index);
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    RemoveAt(index);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IGenericArrayList<T> Repeat(T value, int count)
        {
            GenericArrayList<T> list = new();

            if (count < 0 || count >= int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(value);
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    list.Add(value);
                }
            }
            
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reverse()
        {
            KeyValuePair<T, bool>[] newItems = new KeyValuePair<T, bool>[Count];

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (Count - (i + 1) >= 0)
                        {
                            newItems[Count - (i + 1)] = _items[i];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (Count - (i + 1) >= 0)
                    {
                        newItems[Count - (i + 1)] = _items[i];
                    }
                }
            }
            
            Array.Copy(newItems, 0, _items, 0, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Reverse(int index, int count)
        {
            if (index > Count || index < 0 || count < 1 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }

            List<KeyValuePair<T, bool>> newItems = new();

            int reversedCount = 0;

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (i < index || i > (index + count))
                        {
                            newItems.Add(_items[i]);
                        }
                        else if(i >= index && i <= index + count && reversedCount <= count)
                        {
                            newItems.Insert(i, _items[(index + count) - reversedCount]);
                    
                            reversedCount++;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (i < index || i > (index + count))
                    {
                        newItems.Add(_items[i]);
                    }
                    else if(i >= index && i <= index + count && reversedCount <= count)
                    {
                        newItems.Insert(i, _items[(index + count) - reversedCount]);
                    
                        reversedCount++;
                    }
                }
            }
            
            Array.Copy(newItems.ToArray(), 0, _items, 0, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void SetRange(int index, ICollection<T> collection)
        {
            if (index > Count || index < 0 || collection.Count < 1 || collection.Count > Count)
            {
                throw new IndexOutOfRangeException();
            }

            int i = index;

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    foreach (T item in collection)
                    {
                        Insert(i, item);
                        i++;
                    }
                }
            }
            else
            {
                foreach (T item in collection)
                {
                    Insert(i, item);
                    i++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="enumerable"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void SetRange(int index, IEnumerable<T> enumerable)
        {
            T[] array = enumerable.ToArray();
            if (index > Count || index < 0 || array.Length < 1 || array.Length > Count)
            {
                throw new IndexOutOfRangeException();
            }

            int i = index;

            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    foreach (T item in array)
                    {
                        Insert(i, item);
                        i++;
                    }
                }
            }
            else
            {
                foreach (T item in array)
                {
                    Insert(i, item);
                    i++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Sort()
        {
            Array.Sort(_items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<KeyValuePair<T, bool>> comparer)
        {
            Array.Sort(_items, comparer);   
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="comparer"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Sort(int index, int count, IComparer<KeyValuePair<T, bool>> comparer)
        {
            if (index > Count || index < 0 || count < 1 || count > Count)
            {
                throw new IndexOutOfRangeException();
            }
            
            Array.Sort(_items, index, count, comparer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IGenericArrayList<T> Synchronized(IGenericArrayList<T> source)
        {
            return new GenericArrayList<T>(source.IsReadOnly, source.IsFixedSize, true, source.Capacity, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IList<T> Synchronized(IList<T> source)
        {
            bool isFixedSize = source is T[];

            return new GenericArrayList<T>(source.IsReadOnly, isFixedSize, true, source.Count, source); 
        }

    
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            TrimToSize();
        
            return _items.Select(x => x.Key).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        public void TrimToSize()
        {
            Array.Resize(ref _items, _capacity);
        }

        public bool IsFixedSize => _isFixedSize;
        public bool IsSynchronized { get; protected set; }
        public bool IsReadOnly => _isReadOnly;
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            if (IsSynchronized)
            {
                lock (_items.SyncRoot)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        T key = _items[i].Key;
                
                        if (key is not null && key.Equals(item))
                        {
                            return i;
                        }
                    }
                }   
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    T key = _items[i].Key;
                
                    if (key is not null && key.Equals(item))
                    {
                        return i;
                    }
                }
            }
        
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int index, T item)
        {
            if (index >= int.MaxValue || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (index > Capacity && index == Count + 1)
            {
                Add(item);
            }
            else if(index < Capacity)
            {
                ShiftItemsUpOne(index);
                
                _items[index] = new KeyValuePair<T, bool>(item, false);
            }
        }

        private void ShiftItemsUpOne(int indexStart)
        {
            if (indexStart > Count || indexStart < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
#if NET5_0_OR_GREATER
            if (Count < Array.MaxLength)
#else
            if (Count < int.MaxValue)
#endif
            {
                if (IsSynchronized)
                {
                    lock (_items.SyncRoot)
                    {
                        for (int i = Count + 1; i >= indexStart ; i--)
                        {
                            _items[i] = _items[i - 1];
                        }
                    }
                }
                else
                {
                    for (int i = Count + 1; i >= indexStart ; i--)
                    {
                        _items[i] = _items[i - 1];
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            if ((_count * 2) < _capacity)
            {
                TrimToSize();
            }
            else
            {
                _items[index] = new KeyValuePair<T, bool>(_items[index].Key, false);
            
                CheckIfResizeRequired();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public T this[int index]
        {
            get
            {
                if (index > Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                
                if (_items[index].Value == true)
                {
                    int i = index;

                    if (IsSynchronized)
                    {
                        lock (_items.SyncRoot)
                        {
                            while (i < Count)
                            {
                                if (_items[i].Value == false)
                                {
                                    return _items[i].Key;
                                }

                                i++;
                            }
                        }
                    }
                    else
                    {
                        while (i < Count)
                        {
                            if (_items[i].Value == false)
                            {
                                return _items[i].Key;
                            }

                            i++;
                        }
                    }
                
                    return _items[i].Key;
                }
                else
                {
                    return _items[index].Key;   
                }
            }
            set => _items[index] = new KeyValuePair<T, bool>(value, false);
        }

        public object Clone()
        {
            return this;
        }
    }
}