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

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlastairLundy.Extensions.Collections.IEnumerables
{
    public static class ForEachExtensions
    {
        /// <summary>
        /// Perform a specified action for each item in an IEnumerable.
        /// </summary>
        /// <param name="source">The IEnumerable to be modified.</param>
        /// <param name="action">The action to be performed.</param>
        /// <typeparam name="T">The type of object the IEnumerable enumerates.</typeparam>
        /// <returns>The resulting IEnumerable.</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            T[] enumerable = source as T[] ?? source.ToArray();
        
            for (int i = 0; i < enumerable.Length; i++)
            {
                action.Invoke(enumerable[i]);
            }

            return enumerable;
        }

        /// <summary>
        /// Perform a specified action for each item in an Array.
        /// </summary>
        /// <param name="source">The array to be modified.</param>
        /// <param name="action">The action to be performed.</param>
        /// <typeparam name="T">The type of elements in the Array.</typeparam>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        public static void ForEach<T>(this T[] source, Action<T> action)
        {
            for (int i = 0; i < source.Length; i++)
            {
                action.Invoke(source[i]);
            }
        }
    }
}