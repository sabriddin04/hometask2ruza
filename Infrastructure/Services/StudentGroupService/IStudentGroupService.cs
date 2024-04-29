using Domain.DTO_s.StudentGroup;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.StudentGroupService
{
    public interface IStudentGroupService
    { 
        Task<Response<List<GetStudentGroupDto>>>GetStudentGroupAsync();
        Task<Response<GetStudentGroupDto>> GetStudentGroupByIdAsync(int id); 
        Task<Response<string>>AddStudentGroupAsync(AddStudentGroupDto studentGroupDto); 
        Task<Response<string>>UpdateStudentGroupAsync(UpdateStudentGroupDto studentGroupDto); 
        Task<Response<bool>>DeleteStudentGroupAsync(int id);
    }
}
