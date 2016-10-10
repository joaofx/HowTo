using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DelegateDecompiler;

namespace HowToEntityFramework.Infra
{
    public static class LinqExtensions
    {
        public static IQueryable<T> Include<T, TEnumerable>(this IQueryable<T> queryable, Expression<Func<T, IEnumerable<TEnumerable>>> path)
        {
            var newPath = (Expression<Func<T, IEnumerable<TEnumerable>>>) DecompileExpressionVisitor.Decompile(path);
            return QueryableExtensions.Include(queryable, newPath);
        }
    }
}
