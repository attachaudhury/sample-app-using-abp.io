using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soludevabp.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using soludevabp.Listings;
using soludevabp.Companies;

namespace soludevabp.Listings
{
    [Authorize(soludevabpPermissions.Listings.Default)]
    public class ListingAppService : soludevabpAppService, IListingAppService
    {
        private readonly IListingRepository _listingRepository;
        private readonly ListingManager _listingManager;
        private readonly IRepository<Company, Guid> _companiesRepository;
        public ListingAppService(
            IListingRepository listingRepository,
            ListingManager listingManager,
            IRepository<Company, Guid> companiesRepository)
        {
            _listingRepository = listingRepository;
            _listingManager = listingManager;
            _companiesRepository = companiesRepository;
        }

        //...SERVICE METHODS WILL COME HERE...
        public async Task<ListingDto> GetAsync(Guid id)
        {
            



            var queryable = await _listingRepository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from listing in queryable
                        join company in _companiesRepository on listing.CompanyId equals company.Id
                        where listing.Id == id
                        select new { listing, company };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Listing), id);
            }

            var bookDto = ObjectMapper.Map<Listing, ListingDto>(queryResult.listing);
            bookDto.CompanyName = queryResult.company.Name;
            return bookDto;
        }
        public async Task<PagedResultDto<ListingDto>> GetListAsync(GetListingListDto input)
        {
            //if (input.Sorting.IsNullOrWhiteSpace())
            //{
            //    input.Sorting = nameof(Listing.Name);
            //}

            //var authors = await _listingRepository.GetListAsync(
            //    input.SkipCount,
            //    input.MaxResultCount,
            //    input.Sorting,
            //    input.Filter
            //);

            //var totalCount = input.Filter == null
            //    ? await _listingRepository.CountAsync()
            //    : await _listingRepository.CountAsync(
            //        author => author.Name.Contains(input.Filter));

            //return new PagedResultDto<ListingDto>(
            //    totalCount,
            //    ObjectMapper.Map<List<Listing>, List<ListingDto>>(authors)
            //);





            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Listing.Name);
            }

            //Get the IQueryable<Book> from the repository
            var queryable = await _listingRepository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from listing in queryable
                        join company in _companiesRepository on listing.CompanyId equals company.Id
                        orderby input.Sorting //TODO: Can not sort like that!
                        select new { listing, company };

            //Paging
            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Listing, ListingDto>(x.listing);
                bookDto.CompanyName = x.company.Name;
                return bookDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await _listingRepository.GetCountAsync();

            return new PagedResultDto<ListingDto>(
                totalCount,
                bookDtos
            );

        }
        [Authorize(soludevabpPermissions.Listings.Create)]
        public async Task<ListingDto> CreateAsync(CreateListingDto input)
        {
            var author = await _listingManager.CreateAsync(
                input.Name,
                input.StartDate,
                input.CompanyId,
                input.ShortBio
            );

            await _listingRepository.InsertAsync(author);

            return ObjectMapper.Map<Listing, ListingDto>(author);
        }
        [Authorize(soludevabpPermissions.Listings.Edit)]
        public async Task UpdateAsync(Guid id, UpdateListingDto input)
        {
            var author = await _listingRepository.GetAsync(id);

            if (author.Name != input.Name)
            {
                await _listingManager.ChangeNameAsync(author, input.Name);
            }

            author.StartDate = input.StartDate;
            author.ShortBio = input.ShortBio;

            await _listingRepository.UpdateAsync(author);
        }
        [Authorize(soludevabpPermissions.Listings.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _listingRepository.DeleteAsync(id);
        }
        public async Task<ListResultDto<CompanyLookupDto>> GetCompanyLookupAsync()
        {
            var authors = await _companiesRepository.GetListAsync();

            return new ListResultDto<CompanyLookupDto>(
                ObjectMapper.Map<List<Company>, List<CompanyLookupDto>>(authors)
            );
        }
    }
}
