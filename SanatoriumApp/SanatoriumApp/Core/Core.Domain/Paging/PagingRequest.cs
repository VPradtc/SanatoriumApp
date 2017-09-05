using System;
using Core.Domain.Sorting;

namespace Core.Domain.Paging
{
    public class PagingRequest
    {
        public SortRequest SortRequest { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
