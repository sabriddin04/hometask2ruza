using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class MentorGroup:BaseEntity
    {
        public int MentorId { get; set; }
        public Mentor? Mentor { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
