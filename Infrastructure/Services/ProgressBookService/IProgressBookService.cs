using Domain.DTO_s.ProgressBookDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.ProgressBookService
{
    public interface IProgressBookService
    { 
        Task<PageResponse<List<GetProgressBookDto>>>GetProgressBookAsync(ProgressbookFilter filter);
        Task<Response<GetProgressBookDto>> GetProgressBookById(int id);
        Task<Response<string>> AddProgressBookAsync(AddProgressBookDto progressBookDto); 
        Task<Response<string>> UpdateProgressBookAsync(UpdateProgressBookDto progressBookDto);  
        Task<Response<bool>>DeleteProgressBookAsync(int id);    

    }
}
