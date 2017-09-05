using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class KendoGridRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
