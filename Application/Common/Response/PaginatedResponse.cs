using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Paginated;

namespace Application.Common.PaginatedResponse
{
    public class PaginatedResponse<T>
    {
        public List<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public PaginatedResponse(PaginatedList<T> paginatedList)
        {
            Data = paginatedList.Items;
            PageIndex = paginatedList.PageIndex;
            TotalPages = paginatedList.TotalPages;
            TotalCount = paginatedList.TotalCount;
            HasPreviousPage = paginatedList.HasPreviousPage;
            HasNextPage = paginatedList.HasNextPage;
        }
    }
}
