namespace InterviewTest;

using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    public static RecordList<TSource> ToRecordList<TSource>(this IEnumerable<TSource> source)
    {
        return new(source is IList<TSource> list ? list : source.ToArray());
    }
}
