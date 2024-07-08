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

using AlastairLundy.Extensions.Collections.Dictionaries;

namespace AlastairLundy.Extensions.Collections;

    /// <summary>
    /// A class to store keys and values that tries to mimic how Java's HashMap works.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class HashMap<TKey, TValue> : IHashMap<TKey, TValue>
    {
        // ReSharper disable once InconsistentNaming
        protected Dictionary<TKey, TValue> _dictionary;

        /// <summary>
        /// 
        /// </summary>
        public HashMap()
        {
            _dictionary = new();
        }

        /// <summary>
        /// Returns whether the HashMap is empty or not.
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Returns the number of KeyValuePairs in the HashMap. 
        /// </summary>
        public int Count => _dictionary.Count;
        
        /// <summary>
        /// Add a Key and a corresponding Value to the HashMap.
        /// </summary>
        /// <param name="key">The key to be added.</param>
        /// <param name="value">The value to be associated with the key.</param>
        public void Put(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                _dictionary.Add(key, value);
            }

            throw new ArgumentException($"Existing key {key} found with value {GetValue(key)}. Can't put a Key that already exists.");
        }

        /// <summary>
        /// Add a KeyValuePair to the HashMap.
        /// </summary>
        /// <param name="pair">The KeyValuePair to be added.</param>
        /// <exception cref="ArgumentException"></exception>
        public void Put(KeyValuePair<TKey, TValue> pair)
        {
            Put(pair.Key, pair.Value);
        }

        /// <summary>
        /// Adds a Key and a corresponding value to the HashMap only if the key isn't already in use.
        /// If the key is already present in the HashMap no action is taken.
        /// </summary>
        /// <param name="key">The key to be added.</param>
        /// <param name="value">The value to be associated with the key.</param>
        public void PutIfAbsent(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                Put(key, value);
            }
        }

        /// <summary>
        /// Adds a KeyValuePair to the HashMap only if the key isn't already in use.
        /// If the key is already present in the HashMap no action is taken.
        /// </summary>
        /// <param name="pair">The KeyValuePair to be added to the hashmap.</param>
        public void PutIfAbsent(KeyValuePair<TKey, TValue> pair)
        {
            PutIfAbsent(pair.Key, pair.Value);
        }

        /// <summary>
        /// Returns the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key to be checked.</param>
        /// <returns>The value associated with the specified key if the key is in the HashMap.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the key has not been found in the HashMap.</exception>
        public TValue GetValue(TKey key)
        {
            if (ContainsKey(key))
            {
                return _dictionary[key];
            }
            
            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Returns the value associated with the specified key (if the key exists) or the specified default value.
        /// </summary>
        /// <param name="key">The key to be checked.</param>
        /// <param name="defaultValue">The specified value to be returned if the key has not been found.</param>
        /// <returns>The value associated with the key if the key has been found in the HashMap. Returns the defaultValue otherwise.</returns>
        public TValue GetValueOrDefault(TKey key, TValue defaultValue)
        {
            try
            {
                if (ContainsKey(key))
                {
                    return GetValue(key);
                }
                // ReSharper disable once RedundantIfElseBlock
                else
                {
                    return defaultValue;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns an IEnumerable of Keys in the HashMap.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TKey> Keys()
        {
            return _dictionary.Keys;
        }

        /// <summary>
        /// Returns an IEnumerable of Values in the HashMap.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TValue> Values()
        {
            return _dictionary.Values;
        }

        /// <summary>
        /// Removes the Key and the value associated with it from the HashMap.
        /// </summary>
        /// <param name="key">The Key to be removed.</param>
        /// <returns>true if the item has been successfully removed from the HashMap, and false otherwise.</returns>
        public bool Remove(TKey key)
        {
            if (ContainsKey(key))
            {
                return _dictionary.Remove(key);
            }
            return false;
        }

        /// <summary>
        /// Removes the KeyValuePair from the HashMap.
        /// </summary>
        /// <param name="pair">The KeyValuePair to be removed.</param>
        /// <returns>true if the item has been successfully removed from the HashMap, and false otherwise.</returns>
        /// <exception cref="KeyValuePairNotFoundException"></exception>
        public bool Remove(KeyValuePair<TKey, TValue> pair)
        {
            if (ContainsKeyValuePair(pair))
            {
              return Remove(pair.Key);
            }

            throw new KeyValuePairNotFoundException(nameof(pair));
        }

        /// <summary>
        /// Removes all instances of a specified Value from the HashMap.
        /// </summary>
        /// <param name="value">The specified value to be removed.</param>
        public void RemoveInstancesOf(TValue value)
        {
            TKey[] keys = _dictionary.GetKeys(value).ToArray();

            // ReSharper disable once ForCanBeConvertedToForeach
            for (int index = 0; index < keys.Length; index++)
            {
                Remove(keys[index]);
            }
        }

        /// <summary>
        /// Replaces the value associated with the speicifed Key with a specified Value.
        /// </summary>
        /// <param name="key">The key associated with the value to be replaced.</param>
        /// <param name="value">The replacement value.</param>
        /// <returns>true if the value has been replaced, and false otherwise.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the specified Key isn't found in the HashMap.</exception>
        public bool Replace(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                try
                {
                    _dictionary[key] = value;
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Replaces a specified value associated with the speicifed Key with a specified replacement Value.
        /// </summary> 
        /// <param name="key">The key associated with the value to be replaced and the replacement value.</param>
        /// <param name="oldValue">The value to be replaced.</param>
        /// <param name="newValue">The replacement value.</param>
        /// <returns>true if the oldValue has been replaced with the newValue, and false otherwise.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the specified Key isn't found in the HashMap.</exception>
        public bool Replace(TKey key, TValue oldValue, TValue newValue)
        {
            if (ContainsKey(key))
            {
                if (ContainsKeyValuePair(new KeyValuePair<TKey, TValue>(key, oldValue)))
                {
                    try
                    {
                        _dictionary[key] = newValue;
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Clears the contents of the HashMap.
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }
        
        /// <summary>
        /// Returns the HashMap's internal Dictionary object.
        /// </summary>
        /// <returns></returns>
        public Dictionary<TKey, TValue> ToDictionary()
        {
            return _dictionary;
        }

        /// <summary>
        /// Returns whether the HasMap contains a Key or not.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if the HashMap contains the specified key, and false otherwise.</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Returns whether the HashMap contains a specified value.
        /// </summary>
        /// <param name="value">The specified value.</param>
        /// <returns>true if the HashMap contains the specified value, and false otherwise.</returns>
        public bool ContainsValue(TValue value)
        {
            return _dictionary.ContainsValue(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public bool ContainsKeyValuePair(KeyValuePair<TKey, TValue> pair)
        {
            if (ContainsKey(pair.Key))
            {
                return _dictionary[pair.Key]!.Equals(pair.Value);
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Returns whether a HashMap's internal Dictionary is equal to another HashMap's internal Dictionary.
        /// </summary>
        /// <param name="map">The HashMap to be compared against.</param>
        /// <returns>true if the compared HashMap's Dictionary is equal to this HashMap's internal Dictionary. Returns false otherwise.</returns>
        public bool Equals(HashMap<TKey, TValue> map)
        {
            return _dictionary.Equals(map.ToDictionary());
        }
    }