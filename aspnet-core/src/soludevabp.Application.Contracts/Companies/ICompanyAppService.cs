using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace soludevabp.Companies
{
    public interface ICompanyAppService :
        ICrudAppService< //Defines CRUD methods
            CompanyDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCompanyDto> //Used to create/update a book
    {
    }
}
