/*
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

namespace AlastairLundy.Extensions.Collections.Primitives.Generics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IHashMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// 
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue GetValue(TKey key);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        TValue GetValueOrDefault(TKey key, TValue defaultValue);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainsKey(TKey key);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ContainsValue(TValue value);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        bool ContainsKeyValuePair(KeyValuePair<TKey, TValue> pair);
        
        /// <summary>
        /// 
        /// </summary>
        bool IsEmpty { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Put(TKey key, TValue value);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        void Put(KeyValuePair<TKey, TValue> pair);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void PutIfAbsent(TKey key, TValue value);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        void PutIfAbsent(KeyValuePair<TKey, TValue> pair);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(TKey key);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        bool Remove(KeyValuePair<TKey, TValue> pair);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void RemoveInstancesOf(TValue value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Replace(TKey key, TValue value);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        bool Replace(TKey key, TValue oldValue, TValue newValue);

        /// <summary>
        /// 
        /// </summary>
        void Clear();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<TKey, TValue> ToDictionary();
    }
}