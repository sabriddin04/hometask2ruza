using Domain.DTO_s.MentorGroupDTO;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MentorGroupService
{
    public interface IMentorGroupService
    {
        Task<Response<List<GetMentorGroupDto>>> GetMentorGroupsAsync(); 
        Task<Response<GetMentorGroupDto>>GetMentorGroupByIdAsync(int id);
        Task<Response<string>>AddMentorGroupAsync(AddMentorGroupDto addMentorGroupDto);
        Task<Response<string>>UpdateMentorGroupDtoAsync(UpdateMentorGroupDto updateMentorGroupDto);
        Task<Response<bool>> DeleteMentorGroupdAsync(int id);
    }
}
