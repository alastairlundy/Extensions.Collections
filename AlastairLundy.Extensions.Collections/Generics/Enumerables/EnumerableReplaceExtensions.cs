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

using AlastairLundy.Extensions.Collections.Localizations;

namespace AlastairLundy.Extensions.Collections.IEnumerables;

public static class EnumerableReplaceExtensions
{
    /// <summary>
    /// Replaces the item at a specified index in an IEnumerable with a replacement item.
    /// </summary>
    /// <param name="source">The IEnumerable to be modified.</param>
    /// <param name="index">The index of the item to be replaced.</param>
    /// <param name="newValue">The replacement item.</param>
    /// <typeparam name="T">The type of item.</typeparam>
    /// <returns>The modified IEnumerable with the replacement value at the index provided.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if the index provided is less than 0 or greater than the size of the IEnumerable.</exception>
    public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, int index, T newValue)
    {
        T[] enumerable = source.ToArray();

        if (index < enumerable.Length && index >= 0)
        {
            enumerable[index] = newValue;
        }
        else
        {
            throw new IndexOutOfRangeException(Resources.Exceptions_IndexOutOfRange_Enumerable
                .Replace("{x1}", index.ToString())
                .Replace("{x2}", enumerable.Length.ToString()));
        }

        return enumerable;
    }
    
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
                if (enumerable[index]!.Equals(oldValue))
                {
                    enumerable[index] = newValue;
                }
            }
        }

        return enumerable;
    }
}