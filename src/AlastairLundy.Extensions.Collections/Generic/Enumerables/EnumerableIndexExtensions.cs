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

using System.Collections.Generic;
using System.Linq;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable SuggestVarOrType_BuiltInTypes

namespace AlastairLundy.Extensions.Collections.Generic
{
    public static class EnumerableIndexExtensions
    {
        /// <summary>
        /// Returns the index of an object in an IEnumerable.
        /// </summary>
        /// <param name="source">The IEnumerable to be searched.</param>
        /// <param name="obj">The object to get the index of.</param>
        /// <typeparam name="T">The type of object in the IEnumerable.</typeparam>
        /// <returns>The index of an object in an IEnumerable, if the IEnumerable contains the object; throws an exception otherwise.</returns>
        /// <exception cref="ValueNotFoundException">Thrown if the IEnumerable does not contain the specified object.</exception>
        public static int IndexOf<T>(this IEnumerable<T> source, T obj)
        {
            T[] items = source as T[] ?? source.ToArray();

            for(int index = 0; index < items.Length; index++)
            {
                T item = items[index];
                
                if (item != null && item.Equals(obj))
                {
                    return index;
                }
            }

            throw new ValueNotFoundException(nameof(source), nameof(obj));
        }

        /// <summary>
        /// Gets the indexes of the specified object within an IEnumerable of an object.
        /// </summary>
        /// <param name="source">The IEnumerable to be searched.</param>
        /// <param name="obj">The item to search for.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The indexes if the object is found; a single element Enumerable with a value of -1 otherwise.</returns>
        
        public static IEnumerable<int> IndexesOf<T>(this IEnumerable<T> source, T obj)
        {
            List<int> indexes = new List<int>();
            
            T[] items = source as T[] ?? source.ToArray();

            for(int index = 0; index < items.Length; index++)
            {
                T item = items[index];
                
                if (item != null && item.Equals(obj))
                {
                    indexes.Add(index);
                }
            }

            if (indexes.Count > 0)
            {
                return indexes; 
            }
            else
            {
                return new[]{-1};
            }
        }
    }
}