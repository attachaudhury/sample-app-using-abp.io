using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace soludevabp.Listings
{
    public class GetListingListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
