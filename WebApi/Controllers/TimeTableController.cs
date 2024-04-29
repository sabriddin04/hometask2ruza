using Domain.DTO_s.StudentDTO;
using Domain.DTO_s.TimeTableDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.TimeTableService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/TimeTable")]
    
    public class TimeTableController:ControllerBase
    { 
        private readonly ITimeTableService _TimeTableService;
        public TimeTableController(ITimeTableService timeTableService)
        {
            _TimeTableService = timeTableService;
        }

        [HttpGet]
        public async Task<Response<List<GetTimeTableDto>>> GetTimeTablesAsync(TimeTableFilter filter)
        {
            return await _TimeTableService.GetTimeTableAsync(filter);
        }

        [HttpGet("{timeTableId:int}")]
        public async Task<Response<GetTimeTableDto>> GetTimeTableByIdAsync(int timeTableId)
        {
            return await _TimeTableService.GetTimeTableByIdAync(timeTableId);
        }

        [HttpPost]
        public async Task<Response<string>> AddTimeTableAsync(AddTimeTableDto timeTable)
        {
            return await _TimeTableService.AddTimeTableAsync(timeTable);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateTimeTableAsync(UpdateTimeTableDto timeTable)
        {
            return await _TimeTableService.UpdateTimeTableAsync(timeTable);
        }

        [HttpDelete("{timeTableId:int}")]
        public async Task<Response<bool>> DeleteTimeTableAsync(int timeTableId)
        {
            return await _TimeTableService.DeleteTimeTableAsync(timeTableId);
        }

    }
}
