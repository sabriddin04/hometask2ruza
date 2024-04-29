using AutoMapper;
using Domain.DTO_s.MentorDTO;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Domain.Enteties;
using Domain.Filters;

namespace Infrastructure.Services.MentorService
{
    public class MentorService : IMentorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MentorService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddMentorAsync(AddMentorDto mentor)
        {
            var existing = await _context.Mentors.FirstOrDefaultAsync(x => x.Email == mentor.Email);
            if (existing != null)
            {
                return new Response<string>(HttpStatusCode.BadRequest, "Already exist");
            }

            var mapped = _mapper.Map<Mentor>(mentor);
            await _context.Mentors.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<string>("Succesfully created");
        }

        public async Task<Response<bool>> DeleteMentorAsync(int mentorId)
        {
            try
            {
                var delete = await _context.Mentors.Where(x => x.Id == mentorId).ExecuteDeleteAsync();
                if (delete == 0)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        public async Task<Response<GetMentorDto>> GetMentorByIdsAsync(int id)
        {
            try
            {
                var mentor = await _context.Mentors.FirstOrDefaultAsync(x => x.Id == id);
                if (mentor == null)
                {
                    return new Response<GetMentorDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetMentorDto>(mentor);
                return new Response<GetMentorDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetMentorDto>(HttpStatusCode.BadRequest, e.Message);
            }

        }

        public async Task<PageResponse<List<GetMentorDto>>> GetMentorsAsync(MentorFilter filter)
        {
            try
            {
                var mentors = _context.Mentors.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Address))
                {
                    mentors = mentors.Where(x => x.Address.ToLower().Contains(filter.Address.ToLower()));
                }
                if (!string.IsNullOrEmpty(filter.Email))
                {
                    mentors = mentors.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower()));
                } 
                var response=await mentors
                    .Skip((filter.PageNumber-1)*filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = mentors.Count(); 
                
                var mapped=_mapper.Map<List<GetMentorDto>>(response);
                return new PageResponse<List<GetMentorDto>>(mapped,filter.PageNumber,filter.PageSize,totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetMentorDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateMentorAsync(UpdateMentorDto mentor)
        {
            try
            {
                var mapped = _mapper.Map<Mentor>(mentor);
                _context.Mentors.Update(mapped);
                var update=await _context.SaveChangesAsync();
                if (update==0)
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
