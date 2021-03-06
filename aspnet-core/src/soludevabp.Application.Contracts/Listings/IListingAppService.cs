
using soludevabp.Listings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace soludevabp
{
    public interface IListingAppService : IApplicationService
    {
        Task<ListingDto> GetAsync(Guid id);

        Task<PagedResultDto<ListingDto>> GetListAsync(GetListingListDto input);

        Task<ListingDto> CreateAsync(CreateListingDto input);

        Task UpdateAsync(Guid id, UpdateListingDto input);

        Task DeleteAsync(Guid id);

        Task<ListResultDto<CompanyLookupDto>> GetCompanyLookupAsync();
    }
}
