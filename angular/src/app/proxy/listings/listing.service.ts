import type { CompanyLookupDto, CreateListingDto, GetListingListDto, ListingDto, UpdateListingDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ListingService {
  apiName = 'Default';

  create = (input: CreateListingDto) =>
    this.restService.request<any, ListingDto>({
      method: 'POST',
      url: `/api/app/listing`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/listing/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ListingDto>({
      method: 'GET',
      url: `/api/app/listing/${id}`,
    },
    { apiName: this.apiName });

  getCompanyLookup = () =>
    this.restService.request<any, ListResultDto<CompanyLookupDto>>({
      method: 'GET',
      url: `/api/app/listing/company-lookup`,
    },
    { apiName: this.apiName });

  getList = (input: GetListingListDto) =>
    this.restService.request<any, PagedResultDto<ListingDto>>({
      method: 'GET',
      url: `/api/app/listing`,
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: UpdateListingDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/listing/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
