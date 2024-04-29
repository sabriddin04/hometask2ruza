using Domain.DTO_s.GroupDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.GroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class GroupController:ControllerBase
    { 
        private readonly IGroupService _GroupService;
        public GroupController(IGroupService groupService)
        {
            _GroupService = groupService;
        }

        [HttpGet]
        public async Task<Response<List<GetGroupDto>>> GetGroupsAsync(GroupFilter filter)
        {
            return await _GroupService.GetGroupsAsync(filter);
        }

        [HttpGet("{GroupId:int}")]
        public async Task<Response<GetGroupDto>> GetGroupByIdAsync(int GroupId)
        {
            return await _GroupService.GetGroupByIdAsync(GroupId);
        }

        [HttpPost]
        public async Task<Response<string>> AddGroupAsync(AddGroupDto Group)
        {
            return await _GroupService.AddGroupAsync(Group);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDto Group)
        {
            return await _GroupService.UpdateGroupAsync(Group);
        }

        [HttpDelete("{GroupId:int}")]
        public async Task<Response<bool>> DeleteGroupAsync(int GroupId)
        {
            return await _GroupService.DeleteGroupAsync(GroupId);
        }
    }
}
