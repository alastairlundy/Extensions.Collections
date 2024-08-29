/*
        MIT License
       
       Copyright (c) 2024 Alastair Lundy
       
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

namespace AlastairLundy.Extensions.Collections.IEnumerables;

    /// <summary>
    /// A class to assist in counting the number of times an object or objects appear in an IEnumerable.
    /// </summary>
    public static class FrequencyOfExtensions
    {
        /// <summary>
        ///  Calculates the number of times an object appears in an IEnumerable.
        /// </summary>
        /// <param name="enumerable">The IEnumerable to be searched.</param>
        /// <param name="obj">The object to be searched for.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>the number of times the object appears in the IEnumerable.</returns>
        public static int FrequencyOf<T>(this IEnumerable<T> enumerable, T obj)
        {
            int frequency = 0;

            foreach (T item in enumerable)
            {
                if (item != null && item.Equals(obj))
                {
                    frequency++;
                }
            }

            return frequency;
        }
        
        /// <summary>
        /// Calculates the number of times each distinct object appears in an IEnumerable.
        /// </summary>
        /// <param name="enumerable">The IEnumerable to be searched.</param>
        /// <typeparam name="T">The type of objects in the IEnumerable.</typeparam>
        /// <returns>a Dictionary containing objects and the number of times each one appears in the IEnumerable.</returns>
        public static Dictionary<T, int> FrequencyOfAll<T>(this IEnumerable<T> enumerable)
        {
            Dictionary<T, int> items = new();

            foreach (T item in enumerable)
            {
#if NET6_0_OR_GREATER
                if (!items.TryAdd(item, 1))
#else
                if (items.ContainsKey(item))
#endif
                {
                    items[item] += 1;
                }
            }

            return items;
        }
    }