using Domain.DTO_s.MentorDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MentorService
{
    public interface IMentorService
    {
        Task<PageResponse<List<GetMentorDto>>> GetMentorsAsync(MentorFilter filter); 
        Task<Response<GetMentorDto>> GetMentorByIdsAsync(int mentorId);
        Task<Response<string>> AddMentorAsync(AddMentorDto mentor);
        Task<Response<string>> UpdateMentorAsync(UpdateMentorDto mentor);
        Task<Response<bool>> DeleteMentorAsync(int Id);
    }
}
