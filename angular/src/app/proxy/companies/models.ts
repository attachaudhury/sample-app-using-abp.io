import type { AuditedEntityDto } from '@abp/ng.core';

export interface CompanyDto extends AuditedEntityDto<string> {
  name?: string;
  creteadDate?: string;
}

export interface CreateUpdateCompanyDto {
  name: string;
  creteadDate: string;
}
