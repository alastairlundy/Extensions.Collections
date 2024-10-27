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
using System.Linq;
using AlastairLundy.Extensions.Collections.IEnumerables;
using AlastairLundy.Extensions.System.Indexes;

namespace AlastairLundy.Extensions.Collections.Specializations.Indexes
{
    public static class EnumerableStringIndexesExtensions
    {
        /// <summary>
        /// Gets the indexes of the specified string within an IEnumerable of strings.
        /// </summary>
        /// <param name="strings">The IEnumerable of strings to be searched.</param>
        /// <param name="expected">The string to look for.</param>
        /// <param name="ignoreCase">Whether to ignore the case of the expected string.</param>
        /// <returns>The indexes if the string is found.</returns>
        public static IEnumerable<int> StringIndexesOf(this IEnumerable<string> strings, string expected, bool ignoreCase)
        {
            List<int> indexes = new();
        
            foreach (string str in strings)
            {
                int[] result = str.IndexesOf(expected, ignoreCase).ToArray();

                if (result.Any() && result.Length != 1 && result[0] != -1)
                {
                    indexes = indexes.Combine(result).ToList();
                }
            }

            indexes = indexes.DeDuplicate().ToList();
        
            return indexes;
        }
    }
}