import type { CompanyDto, CreateUpdateCompanyDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  apiName = 'Default';

  create = (input: CreateUpdateCompanyDto) =>
    this.restService.request<any, CompanyDto>({
      method: 'POST',
      url: `/api/app/company`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CompanyDto>({
      method: 'GET',
      url: `/api/app/company/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CompanyDto>>({
      method: 'GET',
      url: `/api/app/company`,
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateCompanyDto) =>
    this.restService.request<any, CompanyDto>({
      method: 'PUT',
      url: `/api/app/company/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
