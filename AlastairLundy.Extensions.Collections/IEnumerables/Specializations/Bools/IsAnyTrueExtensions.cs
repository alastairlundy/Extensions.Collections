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

namespace AlastairLundy.Extensions.Collections.IEnumerables.Specializations.Bools;

public static class IsAnyTrueExtensions
{
    /// <summary>
    /// Returns true if any of the bools in an IEnumerable are true.
    /// </summary>
    /// <param name="source">The IEnumerable to be searched.</param>
    /// <returns>True if any bool in the IEnumerable is true; False otherwise.</returns>
    public static bool IsAnyTrue(this IEnumerable<bool> source)
    {
        return source.Any(x => x == true);
    }
    
    /// <summary>
    /// Returns true if any of the bools in an ICollection are true.
    /// </summary>
    /// <param name="source">The collection to be searched.</param>
    /// <returns>True if any bool in the ICollection is true; False otherwise.</returns>
    public static bool IsAnyTrue(this ICollection<bool> source)
    {
        return source.Any(x => x == true);
    }
}