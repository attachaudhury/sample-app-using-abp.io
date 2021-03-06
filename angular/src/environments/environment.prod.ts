import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'soludevabp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44315',
    redirectUri: baseUrl,
    clientId: 'soludevabp_App',
    responseType: 'code',
    scope: 'offline_access soludevabp',
  },
  apis: {
    default: {
      url: 'https://localhost:44315',
      rootNamespace: 'soludevabp',
    },
  },
} as Environment;
