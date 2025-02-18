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

namespace AlastairLundy.Extensions.Collections.Generics.HashMaps;

/// <summary>
/// The basic interface that ALL HashMap type objects should implement.
/// </summary>
/// <typeparam name="TKey">The type representing Keys in the HashMap.</typeparam>
/// <typeparam name="TValue">The type representing Values in the HashMap.</typeparam>
public interface IHashMapBase<TKey, TValue>
{
    int Count { get; }

    TValue GetValue(TKey key);
    TValue GetValueOrDefault(TKey key, TValue defaultValue);
    
    IDictionary<TKey, TValue> ToDictionary();
    
    bool ContainsKey(TKey key);
    bool ContainsValue(TValue value);
    bool ContainsKeyValuePair(KeyValuePair<TKey, TValue> pair);
}