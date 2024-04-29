using Domain.DTO_s.ProgressBookDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.ProgressBookService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/TimeTable")]
    public class ProgressBookController
    { 
        private readonly IProgressBookService _ProgressBookService;
        public ProgressBookController(IProgressBookService progressBookService)
        {
            _ProgressBookService = progressBookService;
        }

        [HttpGet]
        public async Task<Response<List<GetProgressBookDto>>> GetProgressBooksAsync(ProgressbookFilter filter)
        {
            return await _ProgressBookService.GetProgressBookAsync(filter);
        }

        [HttpGet("{ProgressBookId:int}")]
        public async Task<Response<GetProgressBookDto>> GetProgressBookByIdAsync(int ProgressBookId)
        {
            return await _ProgressBookService.GetProgressBookById(ProgressBookId);
        }

        [HttpPost]
        public async Task<Response<string>> AddProgressBookAsync(AddProgressBookDto ProgressBook)
        {
            return await _ProgressBookService.AddProgressBookAsync(ProgressBook);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateProgressBookAsync(UpdateProgressBookDto ProgressBook)
        {
            return await _ProgressBookService.UpdateProgressBookAsync(ProgressBook);
        }

        [HttpDelete("{ProgressBookId:int}")]
        public async Task<Response<bool>> DeleteProgressBookAsync(int ProgressBookId)
        {
            return await _ProgressBookService.DeleteProgressBookAsync(ProgressBookId);
        }
    }
}
