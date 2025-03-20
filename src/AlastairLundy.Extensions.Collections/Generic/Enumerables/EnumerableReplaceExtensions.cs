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

// ReSharper disable RedundantBoolCompare

namespace AlastairLundy.Extensions.Collections.Generic
{
    public static class EnumerableReplaceExtensions
    {
        /// <summary>
        /// Replaces all occurrences of an item in an IEnumerable with a replacement item.
        /// </summary>
        /// <param name="source">The IEnumerable to be modified.</param>
        /// <param name="oldValue">The value to be replaced.</param>
        /// <param name="newValue">The replacement value.</param>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <returns>The modified IEnumerable if the IEnumerable contains the value to be replaced; Otherwise the original IEnumerable is returned.</returns>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue)
        {
            T[] enumerable = source.ToArray();

            if (enumerable.Contains(oldValue))
            {
                for (int index = 0; index < enumerable.Length; index++)
                {
                    if (enumerable[index]!.Equals(oldValue) == true)
                    {
                        enumerable[index] = newValue;
                    }
                }
            }

            return enumerable;
        }
    }
}