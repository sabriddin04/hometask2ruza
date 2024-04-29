using Domain.DTO_s.StudentDTO;
using Domain.DTO_s.StudentGroup;
using Domain.Response;
using Infrastructure.Services.StudentGroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class StudentGroupController:ControllerBase
    {
        private readonly IStudentGroupService _studentGroupService;
        public StudentGroupController(IStudentGroupService studentGroupService)
        {
            _studentGroupService = studentGroupService;
        }

        [HttpGet]
        public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroupsAsync()
        {
            return await _studentGroupService.GetStudentGroupAsync();
        }

        [HttpGet("{studentGroupId:int}")]
        public async Task<Response<GetStudentGroupDto>> GetStudentGroupByIdAsync(int studentGroupId)
        {
            return await _studentGroupService.GetStudentGroupByIdAsync(studentGroupId);
        }

        [HttpPost]
        public async Task<Response<string>> AddStudentGroupAsync(AddStudentGroupDto studentGroup)
        {
            return await _studentGroupService.AddStudentGroupAsync(studentGroup);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateStudentGroupAsync(UpdateStudentGroupDto studentGroup)
        {
            return await _studentGroupService.UpdateStudentGroupAsync(studentGroup);
        }

        [HttpDelete("{studentGroupId:int}")]
        public async Task<Response<bool>> DeleteStudentGroupAsync(int studentGroupId)
        {
            return await _studentGroupService.DeleteStudentGroupAsync(studentGroupId);
        }
    }
}
