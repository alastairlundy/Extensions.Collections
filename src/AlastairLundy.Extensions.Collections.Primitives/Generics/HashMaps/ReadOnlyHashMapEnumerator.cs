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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlastairLundy.Extensions.Collections.Primitives.Generics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class ReadOnlyHashMapEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>> where TKey : notnull
    {
        
        private readonly ReadOnlyHashMap<TKey, TValue> _hashMap;

        private TKey[] Keys { get; set; }

        private int _position = -1;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashMap"></param>
        public ReadOnlyHashMapEnumerator(ReadOnlyHashMap<TKey, TValue> hashMap)
        {
            _hashMap = hashMap;
            Keys = _hashMap.Keys().ToArray();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            _position++;

           return (_position < _hashMap.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyValuePair<TKey, TValue> Current
        {
            get
            {
                TKey key = Keys[_position];
                TValue value = _hashMap.GetValue(key);
                
                return new KeyValuePair<TKey, TValue>(key, value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        object? IEnumerator.Current => Current;

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Keys = [];
        }
    }
}