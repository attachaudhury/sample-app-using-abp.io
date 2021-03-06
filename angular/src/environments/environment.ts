import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
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
    scope: 'offline_access openid profile role email phone soludevabp',
  },
  apis: {
    default: {
      url: 'https://localhost:44315',
      rootNamespace: 'soludevabp',
    },
  },
} as Environment;
