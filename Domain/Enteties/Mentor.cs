using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Mentor:BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public DateTime DoB { get; set; }
        public List<MentorGroup>? MentorGroups { get; set; }
    } 
}
