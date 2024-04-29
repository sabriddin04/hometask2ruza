using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class GroupFilter:PaginationFilter
    {
        public string? GroupName { get; set; }
    }
}
