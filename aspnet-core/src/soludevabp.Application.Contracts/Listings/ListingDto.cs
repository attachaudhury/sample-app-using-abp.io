using Volo.Abp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace soludevabp.Listings
{
    public class ListingDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string ShortBio { get; set; }

        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
