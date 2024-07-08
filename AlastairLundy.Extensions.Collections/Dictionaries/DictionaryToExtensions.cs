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

using AlastairLundy.Extensions.Collections.HashMaps;

namespace AlastairLundy.Extensions.Collections.Dictionaries;

    public static class DictionaryToExtensions
    {
        /// <summary>
        /// Creates a HashMap object with the values from a Dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of Key in the Dictionary and HashMap.</typeparam>
        /// <typeparam name="TValue">The type of Value in the Dictionary and HashMap.</typeparam>
        /// <param name="dictionary">The Dictionary to get values from.</param>
        /// <returns>a HashMap with the values from the specified Dictionary.</returns>
        public static HashMap<TKey, TValue> ToHashMap<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            HashMap<TKey, TValue> hashMap = new();
            hashMap.PutDictionary(dictionary);

            return hashMap;
        }
    }