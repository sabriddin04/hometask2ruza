using AutoMapper;
using Domain.DTO_s.GroupDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GroupService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddGroupAsync(AddGroupDto group)
        {
            try
            {
                var groups = await _context.Groups.FirstOrDefaultAsync(x =>x.GroupName==group.GroupName);
                if (groups != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Error, already exist");
                }
                var mapped = _mapper.Map<Group>(group);

                await _context.Groups.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteGroupAsync(int Id)
        {
            try
            {
                var student = await _context.Students.Where(x => x.Id == Id).ExecuteDeleteAsync();
                if (student == 0)
                    return new Response<bool>(HttpStatusCode.BadRequest, " Not found");

                return new Response<bool>(true);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetGroupDto>> GetGroupByIdAsync(int groupId)
        {
            try
            {
                var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == groupId);
                if (group == null)
                    return new Response<GetGroupDto>(HttpStatusCode.BadRequest, "Not found");
                var mapped = _mapper.Map<GetGroupDto>(group);
                return new Response<GetGroupDto>(mapped);
            }
            catch (Exception e)
            {
                return new Response<GetGroupDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetGroupDto>>> GetGroupsAsync(GroupFilter filter)
        {
            try
            {
                var groups=_context.Groups.AsQueryable();
                if (!string.IsNullOrEmpty(filter.GroupName))
                {
                    groups = groups.Where(x => x.GroupName.ToLower().Contains(filter.GroupName.ToLower()));
                }
                var response = await groups
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = groups.Count(); 
                var mapped=_mapper.Map<List<GetGroupDto>>(response);
                return new PageResponse<List<GetGroupDto>>(mapped,filter.PageNumber,filter.PageSize,totalRecord);
            }
           
            catch (Exception ex)
            {
                return new PageResponse<List<GetGroupDto>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDto group)
        {
            try
            {
                var mapped = _mapper.Map<Group>(group);
                _context.Groups.Update(mapped);
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
