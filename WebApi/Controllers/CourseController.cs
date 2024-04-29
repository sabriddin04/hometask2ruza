using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CourseController:ControllerBase
    {
        private readonly ICourseService _CourseService;
        public CourseController(ICourseService courseService)
        {
            _CourseService = courseService;
        }

        [HttpGet]
        public async Task<Response<List<GetCourseDto>>> GetCoursesAsync(CourseFilter filter)
        {
            return await _CourseService.GetCoursesAsync(filter);
        }

        [HttpGet("{courseId:int}")]
        public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int courseId)
        {
            return await _CourseService.GetCourseByIdAsync(courseId);
        }

        [HttpGet("Course with active student")] 
        public async Task<Response<List<GetCourseWithActiveStudentsDto>>> GetCoursewithActiveStudent()
        {
            return await _CourseService.GetCourseWithActiveStudentsAsync();
        }

        [HttpPost]
        public async Task<Response<string>> AddCourseAsync(AddCourseDto course)
        {
            return await _CourseService.AddCourseAsync(course);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto course)
        {
            return await _CourseService.UpdateCourseAsync(course);
        }

        [HttpDelete("{courseId:int}")]
        public async Task<Response<bool>> DeleteCourseAsync(int courseId)
        {
            return await _CourseService.DeleteCourseAsync(courseId);
        }
    }
}
