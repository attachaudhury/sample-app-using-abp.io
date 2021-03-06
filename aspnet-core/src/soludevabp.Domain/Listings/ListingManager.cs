using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace soludevabp.Listings
{
    public class ListingManager : DomainService
    {
        private readonly IListingRepository _listingRepository;

        public ListingManager(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        public async Task<Listing> CreateAsync(
            [NotNull] string name,
            DateTime startDate,
            [NotNull] Guid companyId,
            [CanBeNull] string shortBio = null
            )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingListing = await _listingRepository.FindByNameAsync(name);
            if (existingListing != null)
            {
                throw new ListingAlreadyExistsException(name);
            }

            return new Listing(
                GuidGenerator.Create(),
                name,
                startDate,
                companyId,
                shortBio
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Listing listing,
            [NotNull] string newName)
        {
            Check.NotNull(listing, nameof(listing));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingListing = await _listingRepository.FindByNameAsync(newName);
            if (existingListing != null && existingListing.Id != listing.Id)
            {
                throw new ListingAlreadyExistsException(newName);
            }

            listing.ChangeName(newName);
        }
    }
}
