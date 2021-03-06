using AutoMapper;
using soludevabp.Companies;
using soludevabp.Listings;

namespace soludevabp
{
    public class soludevabpApplicationAutoMapperProfile : Profile
    {
        public soludevabpApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Company, CompanyDto>();
            CreateMap<CreateUpdateCompanyDto, Company>();
            CreateMap<Listing, ListingDto>();
            CreateMap<Company, CompanyLookupDto>();
        }
    }
}
