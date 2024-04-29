using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class StudentGroup:BaseEntity
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
