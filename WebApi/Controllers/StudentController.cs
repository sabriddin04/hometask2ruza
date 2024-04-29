using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController:ControllerBase
    { 
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<Response<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter)
        {
            return await _studentService.GetStudentAsync(filter);
        } 

        [HttpGet("{studentId:int}")] 
        public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int studentId)
        {
            return await _studentService.GetStudentByIdAsync(studentId);
        } 

        [HttpGet("Get student with no attendance")] 
        public async Task<Response<List<GetStudentWithNoattendanceDto>>> GetStudentWithNoattendance()
        {
            return await _studentService.GetStudentNoAttendanceAsync();
        } 

        [HttpGet("Get student without course")] 
        public async Task<Response<List<GetStudentWithoutCourseDto>>> GetStudentWithoutCourse()
        {
            return await _studentService.GetStudentsWithoutCourse();
        }

        [HttpGet("Students without practice")] 
        public async Task<Response<List<GetStudentsWithoutPracticeDto>>> GetStudeentWithoutPractice()
        {
            return await _studentService.GetStudentsWithoutPracticeAsync();
        }

        [HttpGet("Student with specific course")] 
        public async Task<Response<List<GetStudentsWithSpecificCourseDto>>> GetStudentWithSpecificCourse()
        {
            return await _studentService.GetStudentsWithSpecificCourseAsync();
        }

        [HttpPost]
        public async Task<Response<string>>AddStudentAsync(AddStudentDto student)
        {
            return await _studentService.AddStudentAsync(student);
        }

        [HttpPut]
        public async Task<Response<string>>UpdateStudentAsync(UpdateStudentDto student)
        {
            return await _studentService.UpdateStudentAsync(student);
        } 

        [HttpDelete("{studentId:int}")] 
        public async Task<Response<bool>>DeleteStudentAsync(int studentId)
        {
            return await _studentService.DeleteStudentAsync(studentId);
        }


    }
}
