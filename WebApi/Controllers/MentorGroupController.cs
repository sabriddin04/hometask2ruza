using Domain.DTO_s.MentorGroupDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Response;
using Infrastructure.Services.MentorGroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MentorGroupController:ControllerBase
    {
        private readonly IMentorGroupService _MentorGroupService;
        public MentorGroupController(IMentorGroupService mentorGroupService)
        {
            _MentorGroupService = mentorGroupService;
        }

        [HttpGet]
        public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroupsAsync()
        {
            return await _MentorGroupService.GetMentorGroupsAsync();
        }

        [HttpGet("{MentorGroupId:int}")]
        public async Task<Response<GetMentorGroupDto>> GetMentorGroupByIdAsync(int MentorGroupId)
        {
            return await _MentorGroupService.GetMentorGroupByIdAsync(MentorGroupId);
        }

        [HttpPost]
        public async Task<Response<string>> AddMentorGroupAsync(AddMentorGroupDto MentorGroup)
        {
            return await _MentorGroupService.AddMentorGroupAsync(MentorGroup);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateMentorGroupAsync(UpdateMentorGroupDto MentorGroup)
        {
            return await _MentorGroupService.UpdateMentorGroupDtoAsync(MentorGroup);
        }

        [HttpDelete("{MentorGroupId:int}")]
        public async Task<Response<bool>> DeleteMentorGroupAsync(int MentorGroupId)
        {
            return await _MentorGroupService.DeleteMentorGroupdAsync(MentorGroupId);
        }
    }
}
