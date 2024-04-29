using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.StudentDTO
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; } 
        public required string  LastName { get; set; } 
        public required string  Address { get; set; } 
        public required string  Phone { get; set; } 
        public required string  Email { get; set; } 
        public string? Status { get; set; }
        public string? Gender { get; set; }
        public DateTime DoB { get; set; }
    }
}
