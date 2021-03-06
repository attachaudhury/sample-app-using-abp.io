using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace soludevabp.Listings
{
    public class CreateListingDto
    {
        [Required]
        [StringLength(ListingConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public string ShortBio { get; set; }
    }
}
