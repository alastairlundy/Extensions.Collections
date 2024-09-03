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

namespace AlastairLundy.Extensions.Collections.Dictionaries;

    public static class DictionaryGetKeyExtensions
    {
        /// <summary>
        /// Gets the Key associated with the specified value in the Dictionary.
        /// This method assumes there is only ONE Key associated with a specific Value in a Dictionary.
        /// If multiple Keys have the same Value use the GetKeys method instead.
        /// </summary>
        /// <param name="dictionary">The Dictionary to be searched.</param>
        /// <param name="value">The value to search for.</param>
        /// <typeparam name="TKey">The type of Key in the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of Value in the Dictionary.</typeparam>
        /// <returns>The key associated with the specified value in a Dictionary.</returns>
        /// <exception cref="ValueNotFoundException">Thrown if the Dictionary does not contain the specified value.</exception>
        public static TKey GetKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
        {
            if (dictionary.ContainsValue(value))
            {
                foreach (KeyValuePair<TKey, TValue> pair in dictionary)
                {
                    if (pair.Value != null && pair.Value.Equals(value))
                    {
                        return pair.Key;
                    }
                }
            }

            throw new ValueNotFoundException(nameof(dictionary), nameof(value));
        }
        
        /// <summary>
        /// Returns all keys associated with a specified value in a Dictionary.
        /// </summary>
        /// <param name="dictionary">The Dictionary to be searched.</param>
        /// <param name="value">The value to search for.</param>
        /// <typeparam name="TKey">The type of Key in the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of Value in the Dictionary.</typeparam>
        /// <returns>The keys associated with the specified value in a Dictionary.</returns>
        /// <exception cref="ValueNotFoundException">Thrown if the specified value is not found within the Dictionary.</exception>
        public static IEnumerable<TKey> GetKeys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
        {
            List<TKey> list = new();
            
            if (dictionary.ContainsValue(value))
            {
                foreach (KeyValuePair<TKey, TValue> pair in dictionary)
                {
                    if (pair.Value != null && pair.Value.Equals(value))
                    {
                        list.Add(pair.Key);
                    }
                }

                return list.ToArray();
            }

            throw new ValueNotFoundException(nameof(dictionary), nameof(value));
        }
        
        /// <summary>
        /// Gets the Key associated with the specified value to a HashMap.
        /// </summary>
        /// <typeparam name="TKey">The type of the Keys used.</typeparam>
        /// <typeparam name="TValue">The type of the Values used.</typeparam>
        /// <param name="hashMap">The HashMap to be added to.</param>
        /// <param name="value">The value to use to return the desired keys.</param>
        /// <returns>The key associated with the value in the HashMap. If more than one Key is associated with the value, only the first key is returned.</returns>
        /// <exception cref="ValueNotFoundException">Thrown if the specified value is not found within the HashMap.</exception>
        public static TKey GetKey<TKey, TValue>(this HashMap<TKey, TValue> hashMap, TValue value)
        {
            return hashMap.ToDictionary().GetKey(value);
        }
        
        /// <summary>
        /// Returns all keys associated with a specified value in a HashMap.
        /// </summary>
        /// <typeparam name="TKey">The type of Key in the HashMap.</typeparam>
        /// <typeparam name="TValue">The type of Value in the HashMap.</typeparam>
        /// <param name="hashMap">The HashMap to be searched.</param>
        /// <param name="value">The value to search for.</param>
        /// <exception cref="ValueNotFoundException">Thrown if the specified value is not found within the HashMap.</exception>
        /// <returns>The keys associated with the specified value in the HashMap.</returns>
        public static IEnumerable<TKey> GetKeys<TKey, TValue>(this HashMap<TKey, TValue> hashMap, TValue value)
        {
            return hashMap.ToDictionary().GetKeys(value);
        }
    }