using Volo.Abp;

namespace soludevabp.Listings
{
    public class ListingAlreadyExistsException : BusinessException
    {
        public ListingAlreadyExistsException(string name)
            : base(soludevabpDomainErrorCodes.ListingAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
