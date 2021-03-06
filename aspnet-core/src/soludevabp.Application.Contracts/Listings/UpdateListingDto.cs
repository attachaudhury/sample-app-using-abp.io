using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace soludevabp.Listings
{
    public class UpdateListingDto
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
