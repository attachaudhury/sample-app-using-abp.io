using soludevabp.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace soludevabp.Companies
{
    public class CompanyAppService :
        CrudAppService<
            Company, //The Book entity
            CompanyDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCompanyDto>, //Used to create/update a book
        ICompanyAppService //implement the IBookAppService
    {
        public CompanyAppService(IRepository<Company, Guid> repository)
            : base(repository)
        {
            GetPolicyName = soludevabpPermissions.Companies.Default;
            GetListPolicyName = soludevabpPermissions.Companies.Default;
            CreatePolicyName = soludevabpPermissions.Companies.Create;
            UpdatePolicyName = soludevabpPermissions.Companies.Edit;
            DeletePolicyName = soludevabpPermissions.Companies.Delete;
        }
    }
}
