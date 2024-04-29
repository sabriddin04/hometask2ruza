using AutoMapper;
using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.GroupDTO;
using Domain.DTO_s.MentorDTO;
using Domain.DTO_s.MentorGroupDTO;
using Domain.DTO_s.ProgressBookDTO;
using Domain.DTO_s.StudentDTO;
using Domain.DTO_s.StudentGroup;
using Domain.DTO_s.TimeTableDTO;
using Domain.Enteties;

namespace Infrastructure.Automapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Mentor, AddMentorDto>().ReverseMap();
            CreateMap<Mentor, GetMentorDto>().ReverseMap();
            CreateMap<Mentor, UpdateMentorDto>().ReverseMap();

            CreateMap<Course, AddCourseDto>().ReverseMap();
            CreateMap<Course, GetCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();

            CreateMap<Group, AddGroupDto>().ReverseMap();
            CreateMap<Group, GetGroupDto>().ReverseMap();
            CreateMap<Group, UpdateGroupDto>().ReverseMap();

            CreateMap<StudentGroup, AddStudentGroupDto>().ReverseMap();
            CreateMap<StudentGroup, GetStudentGroupDto>().ReverseMap();
            CreateMap<StudentGroup, UpdateStudentGroupDto>().ReverseMap();

            CreateMap<MentorGroup, AddMentorGroupDto>().ReverseMap(); 
            CreateMap<MentorGroup, GetMentorGroupDto>().ReverseMap(); 
            CreateMap<MentorGroup, UpdateMentorGroupDto>().ReverseMap();

            CreateMap<ProgressBook, AddProgressBookDto>().ReverseMap(); 
            CreateMap<ProgressBook, GetProgressBookDto>().ReverseMap(); 
            CreateMap<ProgressBook, UpdateProgressBookDto>().ReverseMap(); 

            CreateMap<TimeTable, AddTimeTableDto>().ReverseMap(); 
            CreateMap<TimeTable, GetTimeTableDto>().ReverseMap(); 
            CreateMap<TimeTable, UpdateTimeTableDto>().ReverseMap(); 



        }
    }
}
