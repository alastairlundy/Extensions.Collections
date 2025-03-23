using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.Primitives.BigCollections
{
    public interface IBigReadOnlyCollection<T> : IEnumerable<T>
    {
        void Clear();
    
        bool Contains(T item);
    
        long Count { get; }
    
        bool IsReadOnly { get; }
    }
}