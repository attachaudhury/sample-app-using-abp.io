using soludevabp.Companies;
using soludevabp.Listings;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace soludevabp
{
    public class CompanyStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Company, Guid> _companiesRepository;
        private readonly IListingRepository _authorRepository;
        private readonly ListingManager _authorManager;

        public CompanyStoreDataSeederContributor(IRepository<Company, Guid> companiesRepository, IListingRepository authorRepository,
            ListingManager authorManager)
        {
            _companiesRepository = companiesRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _companiesRepository.GetCountAsync() > 0)
            {
                return;
            }
                var orwell = await _companiesRepository.InsertAsync(
                    new Company
                    {
                        Name = "Company 1",
                        CreteadDate = new DateTime(2020, 6, 8)
                    },
                    autoSave: true
                );

                await _companiesRepository.InsertAsync(
                    new Company
                    {
                        Name = "Company 2",
                        CreteadDate = new DateTime(2019, 9, 27)
                    },
                    autoSave: true
                );

            

            await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Listing 2",
                    new DateTime(1952, 03, 11),
                    orwell.Id,
                    "Listing desc"
                
                    )
            );
        }
    }
}
