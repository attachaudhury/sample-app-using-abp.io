import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyLookupDto extends EntityDto<string> {
  name?: string;
}

export interface CreateListingDto {
  name: string;
  startDate: string;
  companyId: string;
  shortBio?: string;
}

export interface GetListingListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface ListingDto extends EntityDto<string> {
  name?: string;
  startDate?: string;
  shortBio?: string;
  companyId?: string;
  companyName?: string;
}

export interface UpdateListingDto {
  name: string;
  startDate: string;
  companyId: string;
  shortBio?: string;
}
