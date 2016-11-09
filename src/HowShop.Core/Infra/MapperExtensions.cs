using System.Linq;
using AutoMapper.QueryableExtensions;
using DelegateDecompiler;
using X.PagedList;

namespace HowShop.Core.Infra
{
    public static class MapperExtensions
    {
        public static IPagedList<TDestination> ProjectToPagedList<TDestination>(this IQueryable queryable, int pageNumber, int pageSize)
        {
            return queryable.ProjectTo<TDestination>().Decompile().ToPagedList(pageNumber, pageSize);
        }
    }
}
