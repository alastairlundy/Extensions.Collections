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
using System.Collections;
using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.ICollections
{
    public static class CollectionsGetAtExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection">The collection to be searched.</param>
        /// <param name="index">The index position to search an element for.</param>
        /// <param name="value">The value at the index position if one is found; null otherwise.</param>
        /// <returns>true if an item is found at the specified index position; false otherwise.</returns>
        public static bool TryGetAt(this ICollection collection, int index, out object? value)
        {
            try
            {
                value = GetAt(collection, index);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection">The collection to be searched.</param>
        /// <param name="index">The index position to search an element for.</param>
        /// <returns>The item associated with the specified index in the collection.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the greater is larger than the collection or is less than 0.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if no item is found at the specified index.</exception>
        public static object GetAt(this ICollection collection, int index)
        {
            if (index > collection.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            IEnumerator enumerator = collection.GetEnumerator();
            using var enumerator1 = enumerator as IDisposable;

            int internalIndex = 0;
            while (enumerator.MoveNext())
            {
                if (internalIndex == index)
                {
                    if (enumerator.Current != null)
                    {
                        return enumerator.Current;
                    }
                }

                internalIndex++;
            }

            throw new KeyNotFoundException();
        }
    }   
}