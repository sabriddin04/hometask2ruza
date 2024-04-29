using Domain.Enum_s;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Course:BaseEntity
    {
        public string CourseName { get; set; } = null!;
        public string? Description { get; set; }
        public Status Status { get; set; }
        public List<Group>? Groups { get; set; }
    }
}
