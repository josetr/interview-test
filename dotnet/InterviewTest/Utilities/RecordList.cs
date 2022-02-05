namespace InterviewTest;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public sealed class RecordList<T> : ReadOnlyCollection<T>
{
    public RecordList(IList<T> list)
        : base(list)
    {
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj is RecordList<T> list && list.Items.SequenceEqual(Items);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        foreach (T item in Items)
            hashCode.Add(item);
        return hashCode.ToHashCode();
    }
}
