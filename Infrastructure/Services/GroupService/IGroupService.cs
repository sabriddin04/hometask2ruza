using Domain.DTO_s;
using Domain.DTO_s.GroupDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.GroupService
{
    public interface IGroupService
    {
        Task<PageResponse<List<GetGroupDto>>> GetGroupsAsync(GroupFilter filter); 
        Task<Response<GetGroupDto>> GetGroupByIdAsync(int groupId);
        Task<Response<string>> AddGroupAsync(AddGroupDto group);
        Task<Response<string>> UpdateGroupAsync(UpdateGroupDto group);
        Task<Response<bool>> DeleteGroupAsync(int Id);
        
    }
}
