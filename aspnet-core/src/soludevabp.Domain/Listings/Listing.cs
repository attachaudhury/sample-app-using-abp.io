using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace soludevabp.Listings
{
    public class Listing : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; set; }
        public string ShortBio { get; set; }

        public Guid CompanyId { get; set; }

        private Listing()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Listing(
            Guid id,
            [NotNull] string name,
            DateTime startDate,
            Guid companyId,
            [CanBeNull] string shortBio = null
            )
            : base(id)
        {
            SetName(name);
            StartDate = startDate;
            ShortBio = shortBio;
            CompanyId = companyId;
        }

        internal Listing ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: ListingConsts.MaxNameLength
            );
        }
    }
}
