using AutoMapper;
using Domain.DTO_s.StudentDTO;
using Domain.Enteties;
using Domain.Response;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Services.StudentService;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Domain.Filters;
using Domain.Enum_s;



namespace Infrastructure.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region AddStudent 
        public async Task<Response<string>> AddStudentAsync(AddStudentDto studentDto)
        {
            try
            {
                var existing = await _context.Students.FirstOrDefaultAsync(x => x.Email == studentDto.Email);
                if (existing != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
                }
                var mapped = _mapper.Map<Student>(studentDto);

                await _context.Students.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        #endregion

        #region DeleteStudent 
        public async Task<Response<bool>> DeleteStudentAsync(int studentId)
        {
            var delete = await _context.Students.Where(x => x.Id == studentId).ExecuteDeleteAsync();
            if (delete == 0)
            {
                return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
            }
            return new Response<bool>(true);
        }

        #endregion

        public async Task<PageResponse<List<GetStudentDto>>> GetStudentAsync(StudentFilter filter)
        {
            try
            {
                var students = _context.Students.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Address))
                {
                    students = students.Where(x => x.Address.ToLower().Contains(filter.Address!.ToLower()));
                }
                if (!string.IsNullOrEmpty(filter.Email))
                {
                    students = students.Where(x => x.Email.ToLower().Contains(filter.Email!.ToLower()));
                }

                var response = await students
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = students.Count();
                var mapped = _mapper.Map<List<GetStudentDto>>(response);
                return new PageResponse<List<GetStudentDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {
                return new PageResponse<List<GetStudentDto>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
        {
            try
            {
                var create = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (create == null)
                {
                    return new Response<GetStudentDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetStudentDto>(create);
                return new Response<GetStudentDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetStudentDto>(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        public async Task<Response<List<GetStudentWithNoattendanceDto>>> GetStudentNoAttendanceAsync()
        {
            try
            {                
                var students = await(from s in _context.Students 
                                     join p in _context.ProgressBooks on s.Id equals p.StudentId
                                     join t in _context.TimeTables on p.TimeTableId equals t.Id
                                     where t.DayOfWeek==DayOfWeek.Monday
                                     where p.IsAttendance==false
                                     select new GetStudentWithNoattendanceDto
                                     {
                                         Students=s
                                     }
                                     ).ToListAsync();
                return new Response<List<GetStudentWithNoattendanceDto>>(students);
            }
            catch (Exception e)
            {

                return new Response<List<GetStudentWithNoattendanceDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetStudentWithoutCourseDto>>> GetStudentsWithoutCourse()
        {
            var students = await (from s in _context.Students
                                  join sg in _context.StudentGroups on s.Id equals sg.StudentId
                                  join g in _context.Groups on sg.GroupId equals g.Id
                                  join c in _context.Courses on g.CourseId equals c.Id
                                  where c.CourseName == null
                                  select new GetStudentWithoutCourseDto
                                  {
                                      Students = s

                                  }).ToListAsync();
            return new Response<List<GetStudentWithoutCourseDto>>(students);
        }

        public async Task<Response<List<GetStudentsWithoutPracticeDto>>> GetStudentsWithoutPracticeAsync()
        {
            try
            {
                var students = await (from s in _context.Students
                                      join sg in _context.StudentGroups on s.Id equals sg.StudentId
                                      join g in _context.Groups on sg.GroupId equals g.Id
                                      join t in _context.TimeTables on g.Id equals t.GroupId
                                      where t.TimeTableType != TimeTableType.Practice
                                      select new GetStudentsWithoutPracticeDto
                                      {
                                          Students = s
                                      }

                              ).ToListAsync(); 
                return new Response<List<GetStudentsWithoutPracticeDto>>(students);
            }
            catch (Exception e)
            {

                return new Response<List<GetStudentsWithoutPracticeDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetStudentsWithSpecificCourseDto>>> GetStudentsWithSpecificCourseAsync()

        {
            try
            {
                string course = "courseName";

                var students = await (from s in _context.Students
                                      join sg in _context.StudentGroups on s.Id equals sg.StudentId
                                      join g in _context.Groups on sg.GroupId equals g.Id
                                      join c in _context.Courses on g.CourseId equals c.Id
                                      where c.CourseName.ToLower() == course.ToLower()
                                      select new GetStudentsWithSpecificCourseDto
                                      {
                                          Students = s,
                                          CourseName = c.CourseName

                                      }).ToListAsync();
                return new Response<List<GetStudentsWithSpecificCourseDto>>(students);

            }
            catch (Exception e)
            {

                return new Response<List<GetStudentsWithSpecificCourseDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto studentDto)
        {
            try
            {
                var mapped = _mapper.Map<Student>(studentDto);
                _context.Students.Update(mapped);
                var update = await _context.SaveChangesAsync();
                if (update == 0)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<string>("Succesfully updated");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
