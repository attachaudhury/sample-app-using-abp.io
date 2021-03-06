using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace soludevabp.Companies
{
    public class Company : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public DateTime CreteadDate { get; set; }

    }
}
