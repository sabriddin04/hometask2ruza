using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Group:BaseEntity
    {
        public string GroupName { get; set; } = null!;
        public string? Description { get; set; }
        public Status Status { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public List<StudentGroup>? StudentGroups { get; set; }
        public List<MentorGroup>? MentorGroups { get; set; }
        List<ProgressBook>? ProgressBooks { get; set; }
    }
}
