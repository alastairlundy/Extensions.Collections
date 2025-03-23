using System.Collections;
using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.Primitives.BigCollections;

public struct BigGenericArrayListEnumerator<T> : IEnumerator<T>
{
    private readonly BigGenericArrayList<T> _list;

    private int _position = -1;

    public BigGenericArrayListEnumerator(BigGenericArrayList<T> list)
    {
        _list = list;
    }

    public bool MoveNext()
    {
        _position++;
        
        return (_position < _list.Count);
    }

    public void Reset()
    {
        _position = -1;
    }

    public T Current
    {
        get
        {
            if (_position != -1)
            {
                return _list[_position];
            }
            else
            {
                return _list[_list.Count - 1];
            }
        }
    }

    object? IEnumerator.Current => Current;

    public void Dispose()
    {
        _list.Clear();
    }
}