using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;


namespace soludevabp.Listings
{
    public interface IListingRepository : IRepository<Listing, Guid>
    {
        Task<Listing> FindByNameAsync(string name);

        Task<List<Listing>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
