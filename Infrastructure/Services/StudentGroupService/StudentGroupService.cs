using AutoMapper;
using Domain.DTO_s.GroupDTO;
using Domain.DTO_s.StudentGroup;
using Domain.Enteties;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Services.StudentGroupService
{
    public class StudentGroupService:IStudentGroupService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public StudentGroupService(DataContext context,IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<Response<string>> AddStudentGroupAsync(AddStudentGroupDto studentGroupDto)
        {
            try
            {
                
                var mapped = _mapper.Map<StudentGroup>(studentGroupDto);

                await _context.StudentGroups.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
        {
            try
            {
                var studentGroup = await _context.StudentGroups.Where(x => x.Id == id).ExecuteDeleteAsync();
                if (studentGroup == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroupAsync()
        {
            try
            {
                var groups = await _context.StudentGroups.ToListAsync();
                var mapped = _mapper.Map<List<GetStudentGroupDto>>(groups);
                return new Response<List<GetStudentGroupDto>>(mapped);
            }

            catch (Exception ex)
            {
                return new Response<List<GetStudentGroupDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<GetStudentGroupDto>> GetStudentGroupByIdAsync(int id)
        {
            try
            {
                var studentGroup = await _context.StudentGroups.FirstOrDefaultAsync(x => x.Id == id);
                if (studentGroup == null)
                    return new Response<GetStudentGroupDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetStudentGroupDto>(studentGroup);
                return new Response<GetStudentGroupDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetStudentGroupDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateStudentGroupAsync(UpdateStudentGroupDto studentGroupDto)
        {
            try
            {
                var mapped = _mapper.Map<StudentGroup>(studentGroupDto);
                _context.StudentGroups.Update(mapped);
                var update = await _context.SaveChangesAsync();
                if (update == 0) return new Response<string>(HttpStatusCode.BadRequest, "Not found");
                return new Response<string>("Updated successfully");
            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
