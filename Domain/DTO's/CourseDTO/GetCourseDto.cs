﻿using Domain.Enum_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.CourseDTO
{
    public class GetCourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string? Description { get; set; }
        public Status Status { get; set; }
    }
}
