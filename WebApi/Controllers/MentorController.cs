using Domain.DTO_s.MentorDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.MentorService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MentorController:ControllerBase
    {
        private readonly IMentorService _MentorService;
        public MentorController(IMentorService mentorService)
        {
            _MentorService = mentorService;
        }

        [HttpGet]
        public async Task<Response<List<GetMentorDto>>> GetMentorsAsync(MentorFilter filter)
        {
            return await _MentorService.GetMentorsAsync(filter);
        }

        [HttpGet("{MentorId:int}")]
        public async Task<Response<GetMentorDto>> GetMentorByIdAsync(int MentorId)
        {
            return await _MentorService.GetMentorByIdsAsync(MentorId);
        }

        [HttpPost]
        public async Task<Response<string>> AddMentorAsync(AddMentorDto Mentor)
        {
            return await _MentorService.AddMentorAsync(Mentor);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateMentorAsync(UpdateMentorDto Mentor)
        {
            return await _MentorService.UpdateMentorAsync(Mentor);
        }

        [HttpDelete("{MentorId:int}")]
        public async Task<Response<bool>> DeleteMentorAsync(int MentorId)
        {
            return await _MentorService.DeleteMentorAsync(MentorId);
        }
    }
}
