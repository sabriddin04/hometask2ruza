using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.MentorDTO
{
    public class GetMentorDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; } 
        public required string LastName { get; set; }  
        public required string Address { get; set; }  
        public required string Phone { get; set; }  
        public required string Email { get; set; }  
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public DateTime DoB { get; set; }
    }
}
