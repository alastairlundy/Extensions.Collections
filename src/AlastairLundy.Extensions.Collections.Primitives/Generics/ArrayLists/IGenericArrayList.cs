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

    public interface IGenericArrayList<T> : IList<T>, ICloneable
    {
        bool IsFixedSize { get; }

        bool IsSynchronized { get; }
    
        int Capacity { get; }
    
        void AddRange(ICollection<T> collection);
     
        int BinarySearch(int index, int count, T value, IComparer<T> comparer); 
        int BinarySearch(T value, IComparer<T> comparer);

        void CopyTo(T[] array);
        void CopyTo(int index, T[] array, int arrayIndex, int count);
     
        IGenericArrayList<T> FixedSize(IGenericArrayList<T> source);
        IList<T> FixedSize(IList<T> source);
     
        IGenericArrayList<T> GetRange(int index, int count);

        int IndexOf(T? value, int startIndex);
        int IndexOf(T? value, int startIndex, int count);

        void InsertRange(int index, ICollection<T> collection);
     
        int LastIndexOf(T value);
        int LastIndexOf(T value, int startIndex);
        int LastIndexOf(T value, int startIndex, int count);
     
        IGenericArrayList<T> ReadOnly(IGenericArrayList<T> source);
        IList<T> ReadOnly(IList<T> source);

        void RemoveRange(int index, int count);
     
        IGenericArrayList<T> Repeat(T value, int count);
     
        /// <summary>
        /// 
        /// </summary>
        void Reverse();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        void Reverse(int index, int count);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        void SetRange(int index, ICollection<T> collection);

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IGenericArrayList<T> Synchronized(IGenericArrayList<T> source);
          
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IList<T> Synchronized(IList<T> source);
     
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
          
        /// <summary>
        /// 
        /// </summary>
        void TrimToSize();
    }
}