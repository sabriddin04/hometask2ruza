using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class TimeTable
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public TimeTableType TimeTableType { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        List<ProgressBook>? ProgressBooks { get; set; }
    }
}
