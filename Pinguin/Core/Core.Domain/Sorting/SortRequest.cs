using System;

namespace Core.Domain.Sorting
{
    public class SortRequest
    {
        public SortDirection? SortDirection { get; set; }
        public string SortField { get; set; }
    }
}
