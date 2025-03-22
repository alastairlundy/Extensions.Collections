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

using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.Primitives.BigCollections;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBigGenericArrayList<T> : IBigList<T>
{

    bool IsFixedSize { get; }

    bool IsSynchronized { get; }
    
    long Capacity { get; }
    
    void AddRange(ICollection<T> collection);
     
    long BinarySearch(long index, long count, T value, IComparer<T> comparer); 
    long BinarySearch(T value, IComparer<T> comparer);

    void CopyTo(BigArray<T> array);
    void CopyTo(long index, BigArray<T> array, long arrayIndex, long count);
     
    IBigGenericArrayList<T> FixedSize(IBigGenericArrayList<T> source);
    IBigList<T> FixedSize(IBigList<T> source);
     
    IBigGenericArrayList<T> GetRange(long index, long count);

    long IndexOf(T? value, long startIndex);
    long IndexOf(T? value, long startIndex, long count);

    void InsertRange(long index, ICollection<T> collection);
     
    long LastIndexOf(T value);
    long LastIndexOf(T value, long startIndex);
    long LastIndexOf(T value, long startIndex, long count);
     
    IBigGenericArrayList<T> ReadOnly(IBigGenericArrayList<T> source);
    IList<T> ReadOnly(IList<T> source);

    void RemoveRange(long index, long count);
     
    IBigGenericArrayList<T> Repeat(T value, long count);
     
    /// <summary>
    /// 
    /// </summary>
    void Reverse();
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    void Reverse(long index, long count);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="collection"></param>
    void SetRange(long index, ICollection<T> collection);
    
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
    void Sort(long index, long count, IComparer<T> comparer);
    
    IBigGenericArrayList<T> Synchronized(IBigGenericArrayList<T> source);
    
    IBigList<T> Synchronized(IBigList<T> source);
    
    BigArray<T> ToArray();
    
    /// <summary>
    /// 
    /// </summary>
    void TrimToSize();
}