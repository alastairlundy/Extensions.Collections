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
using System.Linq;

namespace AlastairLundy.Extensions.Collections.HashMaps
{
    public static class HashMapPutExtensions
    {
        /// <summary>
        /// Adds the Key Value Pairs in a Dictionary to a HashMap.
        /// </summary>
        /// <param name="source">The HashMap to have Key Value Pairs added to it.</param>
        /// <param name="dictionaryToAdd">The Dictionary to get the Key Value Pairs from.</param>
        /// <typeparam name="TKey">The type of Key in the HashMap and Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of Value in the HashMap and Dictionary.</typeparam>
        public static void PutDictionary<TKey, TValue>(this HashMap<TKey, TValue> source, IDictionary<TKey, TValue> dictionaryToAdd)
        {
            foreach (KeyValuePair<TKey, TValue> pair in dictionaryToAdd)
            {
                if (source.Count == int.MaxValue)
                {
                    throw new OverflowException($"{nameof(source)}  has reached the maximum size of {int.MaxValue} and cannot be added to.");
                }
                else if (dictionaryToAdd.Count == int.MaxValue)
                {
                    throw new OverflowException($"{nameof(dictionaryToAdd)}  has reached the maximum size of {int.MaxValue} and cannot be added to {nameof(source)}.");
                }
                
                source.Put(pair);
            }
        }
        
        /// <summary>
        /// Adds items in a HashTable to a HashMap.
        /// </summary>
        /// <typeparam name="TKey">The type of the Keys used.</typeparam>
        /// <typeparam name="TValue">The type of the Values used.</typeparam>
        /// <param name="source">The HashMap to be added to.</param>
        /// <param name="hashtable">The table to have items added to the HashMap</param>
        [Obsolete("This code is deprecated and will be removed in a future version. Please use PutDictionary instead.")]
        public static void PutHashTable<TKey, TValue>(this HashMap<TKey, TValue> source, Hashtable hashtable)
        {
            ICollection keys = hashtable.Keys;
            ICollection values = hashtable.Values;
            
            TKey[] keyArray = new TKey[keys.Count];
            TValue[] valArray = new TValue[values.Count];

            values.CopyTo(valArray, 0);
            keys.CopyTo(keyArray, 0);

            if (keys.Count == values.Count)
            {
                for (int index = 0; index < keys.Count; index++)
                {
                    if (source.Count == int.MaxValue)
                    {
                        throw new OverflowException($"{nameof(source)}  has reached the maximum size of {int.MaxValue} and cannot be added to.");
                    }
                    else if (hashtable.Count == int.MaxValue)
                    {
                        throw new OverflowException($"{nameof(hashtable)}  has reached the maximum size of {int.MaxValue} and cannot be added to {nameof(source)}.");
                    }       
                    
                    source.Put(keyArray[index], valArray[index]);
                }
            }
        }
        
        /// <summary>
        /// Adds items in an IEnumerable to a HashMap
        /// </summary>
        /// <typeparam name="TKey">The type of the Keys used.</typeparam>
        /// <typeparam name="TValue">The type of the Values used.</typeparam>
        /// <param name="source">The HashMap to be added to.</param>
        /// <param name="enumerable">The IEnumerable of items to add to the HashMap.</param>
        public static void PutEnumerable<TKey, TValue>(this HashMap<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
        {
            KeyValuePair<TKey, TValue>[] keyValuePairs = enumerable as KeyValuePair<TKey, TValue>[] ?? enumerable.ToArray();
            
            foreach(KeyValuePair<TKey, TValue> pair in keyValuePairs)
            {
                if (source.Count == int.MaxValue)
                {
                    throw new OverflowException($"{nameof(source)} has reached the maximum size of {int.MaxValue} and cannot be added to.");
                }
                else if (keyValuePairs.Length == int.MaxValue)
                {
                    throw new OverflowException($"{nameof(enumerable)} has reached the maximum size of {int.MaxValue} and cannot be added to {nameof(source)}.");
                }
                
                source.Put(pair);
            }
        }
    }
}