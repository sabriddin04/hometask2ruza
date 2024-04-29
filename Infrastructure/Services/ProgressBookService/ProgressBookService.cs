using AutoMapper;
using Domain.DTO_s.ProgressBookDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enteties;
using Microsoft.EntityFrameworkCore;
using Domain.DTO_s.StudentDTO;

namespace Infrastructure.Services.ProgressBookService
{
    
    public class ProgressBookService : IProgressBookService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProgressBookService(DataContext context,IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public async Task<Response<string>> AddProgressBookAsync(AddProgressBookDto progressBookDto)
        {
            try
            {
                var mapped = _mapper.Map<ProgressBook>(progressBookDto);

                await _context.ProgressBooks.AddAsync(mapped);
                await _context.SaveChangesAsync();

                return new Response<string>("Succesfully added");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteProgressBookAsync(int id)
        {
            var delete = await _context.ProgressBooks.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (delete == 0)
            {
                return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
            }
            return new Response<bool>(true);
        }

        public async Task<PageResponse<List<GetProgressBookDto>>> GetProgressBookAsync(ProgressbookFilter filter)
        {
            try
            {
                var progress =  _context.ProgressBooks.AsQueryable();
                var response = await progress
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = progress.Count();
                var mapped = _mapper.Map<List<GetProgressBookDto>>(response);
                return new PageResponse<List<GetProgressBookDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {
                return new PageResponse<List<GetProgressBookDto>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<GetProgressBookDto>> GetProgressBookById(int id)
        {
            try
            {
                var create = await _context.ProgressBooks.FirstOrDefaultAsync(x => x.Id == id);
                if (create == null)
                {
                    return new Response<GetProgressBookDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetProgressBookDto>(create);
                return new Response<GetProgressBookDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetProgressBookDto>(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        public async Task<Response<string>> UpdateProgressBookAsync(UpdateProgressBookDto progressBookDto)
        {
            try
            {
                var mapped = _mapper.Map<ProgressBook>(progressBookDto);
                _context.ProgressBooks.Update(mapped);
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
