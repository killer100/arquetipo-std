using AutoMapper;
using Release.Helper;
using Release.Helper.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace Prod.STD.Core
{
    public static class DbExtensions
    {
        public static PagedResponse<TDestination> PagedResponse<TSource, TDestination>(this IQueryable<TSource> source, PagedRequest page, IMapper mapper) where TDestination : class
        {
            var paged = source.PagedResponse(page);
            var items = mapper.Map<ICollection<TSource>, ICollection<TDestination>>(paged.Data);
            return new PagedResponse<TDestination>
            {
                Data = items,
                TotalPages = paged.TotalPages,
                TotalRows = paged.TotalRows,
                Status = new StatusResponse { Success = items.Any() }
            };
        }
    }
}
