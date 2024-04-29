using AutoMapper;
using Domain.DTO_s.StudentDTO;
using Domain.DTO_s.TimeTableDTO;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.TimeTableService
{
    public class TimeTableService : ITimeTableService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TimeTableService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<string>> AddTimeTableAsync(AddTimeTableDto timeTableDto)
        {
            try
            {
                var mapped = _mapper.Map<TimeTable>(timeTableDto);

                await _context.TimeTables.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");

            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<bool>> DeleteTimeTableAsync(int id)
        {
            var delete = await _context.TimeTables.Where(x => x.Id ==id).ExecuteDeleteAsync();
            if (delete == 0)
            {
                return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
            }
            return new Response<bool>(true);
        }

        public async Task<PageResponse<List<GetTimeTableDto>>> GetTimeTableAsync(TimeTableFilter filter)
        {
            try
            {
                var times = _context.TimeTables.AsQueryable();
                if (!string.IsNullOrEmpty(filter.DayOfWeek.ToString()))
                {
                    times = times.Where(x => x.DayOfWeek.ToString().ToLower()
                    .Contains(filter.DayOfWeek.ToString()!.ToLower()));
                }
               

                var response = await times
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = times.Count();
                var mapped = _mapper.Map<List<GetTimeTableDto>>(response);
                return new PageResponse<List<GetTimeTableDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {
                return new PageResponse<List<GetTimeTableDto>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<GetTimeTableDto>> GetTimeTableByIdAync(int id)
        {
            try
            {
                var create = await _context.TimeTables.FirstOrDefaultAsync(x => x.Id == id);
                if (create == null)
                {
                    return new Response<GetTimeTableDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetTimeTableDto>(create);
                return new Response<GetTimeTableDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetTimeTableDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateTimeTableAsync(UpdateTimeTableDto timeTableDto)
        {
            try
            {
                var mapped = _mapper.Map<TimeTable>(timeTableDto);
                _context.TimeTables.Update(mapped);
                var update = await _context.SaveChangesAsync();
                if (update == 0)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<string>("Succesfully updated");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
