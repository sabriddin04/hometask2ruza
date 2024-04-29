using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.GroupDTO
{
    public class AddGroupDto
    {
        public required string GroupName { get; set; } 
        public string? Description { get; set; }
        public Status Status { get; set; }
        
        public int CourseId { get; set; }
    }
}
