using AutoMapper;
using Domain.DTO_s.GroupDTO;
using Domain.DTO_s.MentorGroupDTO;
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

namespace Infrastructure.Services.MentorGroupService
{
    public class MentorGroupService:IMentorGroupService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MentorGroupService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<Response<string>> AddMentorGroupAsync(AddMentorGroupDto addMentorGroupDto)
        {
            try
            {
                
                var mapped = _mapper.Map<MentorGroup>(addMentorGroupDto);

                await _context.MentorsGroups.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteMentorGroupdAsync(int id)
        {
            try
            {
                var mentorGroup = await _context.Students.Where(x => x.Id == id).ExecuteDeleteAsync();
                if (mentorGroup == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetMentorGroupDto>> GetMentorGroupByIdAsync(int id)
        {
            try
            {
                var mentorGroup = await _context.MentorsGroups.FirstOrDefaultAsync(x => x.Id == id);
                if (mentorGroup == null)
                    return new Response<GetMentorGroupDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetMentorGroupDto>(mentorGroup);
                return new Response<GetMentorGroupDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetMentorGroupDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroupsAsync()
        {
            try
            {
                var mentorGroups = await _context.MentorsGroups.ToListAsync();
                var mapped = _mapper.Map<List<GetMentorGroupDto>>(mentorGroups);
                return new Response<List<GetMentorGroupDto>>(mapped);
            }

            catch (Exception ex)
            {
                return new Response<List<GetMentorGroupDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> UpdateMentorGroupDtoAsync(UpdateMentorGroupDto updateMentorGroupDto)
        {
            try
            {
                var mapped = _mapper.Map<MentorGroup>(updateMentorGroupDto);
                _context.MentorsGroups.Update(mapped);
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
