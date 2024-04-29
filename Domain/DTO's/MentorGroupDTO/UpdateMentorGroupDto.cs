using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.MentorGroupDTO
{
    public class UpdateMentorGroupDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MentorId { get; set; }
    }
}
