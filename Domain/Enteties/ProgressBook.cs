using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class ProgressBook:BaseEntity
    {
        public int Grade { get; set; }
        public bool IsAttendance { get; set; }
        public string? Notes { get; set; }
        public int LateMinute { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public int TimeTableId { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Group? Group { get; set; }
        public virtual TimeTable? TimeTable { get; set; } 

    }
}
