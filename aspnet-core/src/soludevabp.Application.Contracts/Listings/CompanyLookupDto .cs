using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace soludevabp.Listings
{
    public class CompanyLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
