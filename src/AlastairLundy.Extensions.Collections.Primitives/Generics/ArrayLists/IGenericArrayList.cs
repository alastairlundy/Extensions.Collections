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
using System.Collections.Generic;

// ReSharper disable ArrangeNamespaceBody
// ReSharper disable UnusedMember.Global

namespace AlastairLundy.Extensions.Collections.Primitives.Generics
{

    /// <summary>
    /// An interface for a Generic Array List.
    /// </summary>
    /// <typeparam name="T">The type of object to be stored.</typeparam>
    public interface IGenericArrayList<T> : IList<T>, ICloneable
    {
        /// <summary>
        /// Whether the Generic Array List is a fixed size or not.
        /// </summary>
        bool IsFixedSize { get; }

        /// <summary>
        /// Whether the Generic Array List is thread-safe or not.
        /// </summary>
        bool IsSynchronized { get; }
    
        /// <summary>
        /// The capacity of the Generic Array List.
        /// </summary>
        int Capacity { get; }
    
        /// <summary>
        /// Adds a collection of items to the Generic Array List.
        /// </summary>
        /// <param name="collection">The collection to add.</param>
        void AddRange(ICollection<T> collection);
        
        /// <summary>
        /// Adds an IEnumerable of items to the Generic Array List.
        /// </summary>
        /// <param name="enumerable">The IEnumerable to add.</param>
        void AddRange(IEnumerable<T> enumerable);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        int BinarySearch(int index, int count, T value, IComparer<T> comparer); 
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        int BinarySearch(T value, IComparer<T> comparer);

        /// <summary>
        /// Copies the contents of the Generic Array List to an Array.
        /// </summary>
        /// <param name="array">The array to copy to.</param>
        void CopyTo(T[] array);
        
        /// <summary>
        /// Copies a specified amount of items from one Generic Array List from to an Array 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <param name="count"></param>
        void CopyTo(int index, T[] array, int arrayIndex, int count);
     
        /// <summary>
        /// Creates a Fixed Size Generic Array List from a source Generic Array List.
        /// </summary>
        /// <param name="source">The source to make a fixed size copy of.</param>
        /// <returns>The fixed size version of the source.</returns>
        IGenericArrayList<T> FixedSize(IGenericArrayList<T> source);
        
        /// <summary>
        /// Creates a Fixed Size List from a source IList.
        /// </summary>
        /// <param name="source">The source to make a fixed size copy of.</param>
        /// <returns>The fixed size version of the source.</returns>
        IList<T> FixedSize(IList<T> source);
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IGenericArrayList<T> GetRange(int index, int count);

        /// <summary>
        /// Gets the index of the specified value.
        /// </summary>
        /// <param name="value">The item to be found.</param>
        /// <param name="startIndex">The index to start looking for the item at.</param>
        /// <returns>The index of the item.</returns>
        int IndexOf(T? value, int startIndex);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The item to be found.</param>
        /// <param name="startIndex">The index to start looking for the item at.</param>
        /// <param name="count">The number of </param>
        /// <returns></returns>
        int IndexOf(T? value, int startIndex, int count);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        void InsertRange(int index, ICollection<T> collection);
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int LastIndexOf(T value);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        int LastIndexOf(T value, int startIndex);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int LastIndexOf(T value, int startIndex, int count);
     
        /// <summary>
        /// Creates a read only copy of a Generic Array List.
        /// </summary>
        /// <param name="source">The source to make a read only copy of.</param>
        /// <returns>A read only copy of the Generic Array List.</returns>
        IGenericArrayList<T> ReadOnly(IGenericArrayList<T> source);
        
        /// <summary>
        /// Creates a read only copy of an IList.
        /// </summary>
        /// <param name="source">The source to make a read only copy of.</param>
        /// <returns>A read only copy of the IList.</returns>
        IList<T> ReadOnly(IList<T> source);

        /// <summary>
        /// Removes a range of items starting from a specified index.
        /// </summary>
        /// <param name="index">The index to start removing items from.</param>
        /// <param name="count">The number of items to remove from the Generic Array List.</param>
        void RemoveRange(int index, int count);
     
        /// <summary>
        /// Creates a new Generic Array List with a specified number of copies of a value.
        /// </summary>
        /// <param name="value">The value to fill the new Generic Array List in.</param>
        /// <param name="count">The number of copies of the value to add to the new Generic Array List.</param>
        /// <returns>The new Generic Array List with the copies of the specified value.</returns>
        IGenericArrayList<T> Repeat(T value, int count);
     
        /// <summary>
        /// Reverses the items in the Generic Array List.
        /// </summary>
        void Reverse();
        
        /// <summary>
        /// Reverses the selected items in the Generic Array List.
        /// </summary>
        /// <param name="index">The index to start reversing the selected items.</param>
        /// <param name="count">The number of items to reverse.</param>
        void Reverse(int index, int count);

        /// <summary>
        /// Sets a collection of objects to positions in the Generic Array List from the starting index.
        /// </summary>
        /// <param name="index">The index to set the objects from.</param>
        /// <param name="collection">The collection of items to set to positions in the Generic Array List.</param>
        void SetRange(int index, ICollection<T> collection);
        
        /// <summary>
        /// Sets a IEnumerable of objects to positions in the Generic Array List from the starting index.
        /// </summary>
        /// <param name="index">The index to set the objects from.</param>
        /// <param name="enumerable">The IEnumerable of items to set to positions in the Generic Array List.</param>
        void SetRange(int index, IEnumerable<T> enumerable);

        /// <summary>
        /// Sorts the Generic Array List.
        /// </summary>
        void Sort();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparer"></param>
        void Sort(IComparer<T> comparer);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="comparer"></param>
        void Sort(int index, int count, IComparer<T> comparer);
        
        /// <summary>
        /// Creates a thread-safe copy of the source Generic Array List.
        /// </summary>
        /// <param name="source">The source to make a thread-safe copy of.</param>
        /// <returns>A thread-safe copy of the Generic Array List.</returns>
        IGenericArrayList<T> Synchronized(IGenericArrayList<T> source);
          
        /// <summary>
        /// Creates a thread-safe copy of the source IList.
        /// </summary>
        /// <param name="source">The source to make a thread-safe copy of.</param>
        /// <returns>A thread-safe copy of the IList.</returns>
        IList<T> Synchronized(IList<T> source);
     
        /// <summary>
        /// Returns the 
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
          
        /// <summary>
        /// Trims the internal array, used by the Generic Array List, to the number of items in the array..
        /// </summary>
        void TrimToSize();
    }
}