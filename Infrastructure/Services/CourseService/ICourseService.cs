using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.CourseService
{
    public interface ICourseService
    {
        Task<PageResponse<List<GetCourseDto>>> GetCoursesAsync(CourseFilter filter);
        Task<Response<List<GetCourseWithActiveStudentsDto>>> GetCourseWithActiveStudentsAsync();
        Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
        Task<Response<string>> AddCourseAsync(AddCourseDto course);
        Task<Response<string>> UpdateCourseAsync(UpdateCourseDto course);
        Task<Response<bool>> DeleteCourseAsync(int Id);
    }
}
