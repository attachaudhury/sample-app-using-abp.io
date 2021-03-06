using System;
using Volo.Abp.Application.Dtos;

namespace soludevabp.Companies
{
    public class CompanyDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime CreteadDate { get; set; }
    }
}
