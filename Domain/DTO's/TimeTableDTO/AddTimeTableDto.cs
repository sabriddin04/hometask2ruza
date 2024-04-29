using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.TimeTableDTO
{
    public class AddTimeTableDto
    {       
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public TimeTableType TimeTableType { get; set; }
    }
}
