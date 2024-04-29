using Domain.DTO_s.TimeTableDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.TimeTableService
{
    public interface ITimeTableService
    { 
        Task<PageResponse<List<GetTimeTableDto>>> GetTimeTableAsync(TimeTableFilter filter);
        Task<Response<GetTimeTableDto>> GetTimeTableByIdAync(int id);
        Task<Response<string>> AddTimeTableAsync(AddTimeTableDto timeTableDto); 
        Task<Response<string>> UpdateTimeTableAsync(UpdateTimeTableDto timeTableDto);
        Task<Response<bool>>DeleteTimeTableAsync(int id);
    }
}
