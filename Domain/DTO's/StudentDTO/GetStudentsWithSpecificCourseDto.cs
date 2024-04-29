using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.StudentDTO
{
    public class GetStudentsWithSpecificCourseDto
    {
        public Student? Students { get; set; }
        public string? CourseName { get; set; }
    }
}
