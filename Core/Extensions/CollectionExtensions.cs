using System.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace Core.Extensions;

public static class CollectionExtensions
{
    public static IList<T> Paginate<T>(this IEnumerable<T> list, int page, int pageSize)
    {
        if (page <= 0)
            page = 1;
        if (pageSize <= 0)
            pageSize = 10;

        return pageSize == int.MaxValue
            ? list.ToList()
            : list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public static IList<T> Paginate<T>(this IQueryable<T> list, int page, int pageSize)
    {
        if (page <= 0)
            page = 1;
        if (pageSize <= 0)
            pageSize = 10;

        return pageSize == int.MaxValue
            ? list.ToList()
            : list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public static async Task<IList<T>> PaginateAsync<T>(this IQueryable<T> list, int page, int pageSize)
    {
        if (page <= 0)
            page = 1;
        if (pageSize <= 0)
            pageSize = 10;

        if (pageSize == int.MaxValue)
            return await list.ToListAsync();

        return await list
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public static object ToObject(this Dictionary<string, object> dict)
    {
        if (dict.Count == 0)
            return new object();

        var obj = new ExpandoObject();

        foreach (var pair in dict)
            obj.TryAdd(pair.Key, pair.Value);

        return obj;
    }
}