import type { CreateUpdateMessageDto, IdentityUserLookupDto, MessageDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  apiName = 'Default';

  create = (input: CreateUpdateMessageDto) =>
    this.restService.request<any, MessageDto>({
      method: 'POST',
      url: '/api/app/message',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/message/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, MessageDto>({
      method: 'GET',
      url: `/api/app/message/${id}`,
    },
    { apiName: this.apiName });

  getCurrentUserId = () =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/message/current-user-id',
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<MessageDto>>({
      method: 'GET',
      url: '/api/app/message',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  getUserLookup = () =>
    this.restService.request<any, ListResultDto<IdentityUserLookupDto>>({
      method: 'GET',
      url: '/api/app/message/user-lookup',
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateMessageDto) =>
    this.restService.request<any, MessageDto>({
      method: 'PUT',
      url: `/api/app/message/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
