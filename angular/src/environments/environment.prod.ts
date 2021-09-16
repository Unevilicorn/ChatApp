import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ChatApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44378',
    redirectUri: baseUrl,
    clientId: 'ChatApp_App',
    responseType: 'code',
    scope: 'offline_access ChatApp',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44378',
      rootNamespace: 'ChatApp',
    },
  },
} as Environment;
