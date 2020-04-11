using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.ListExtensions
{
    public static class ListExtensions
    {
        public static List<List<T>> DividePor<T>(this List<T> lista, int corte)
        {
            return lista
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / corte)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
