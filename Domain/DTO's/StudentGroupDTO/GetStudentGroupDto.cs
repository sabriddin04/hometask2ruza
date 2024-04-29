using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.StudentGroup
{
    public class GetStudentGroupDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
    }
}
