import type { EntityDto } from '@abp/ng.core';

export interface CreateUpdateMessageDto {
  content: string;
  postDate: string;
  userId: string;
  channelId?: string;
}

export interface IdentityUserLookupDto extends EntityDto<string> {
  name?: string;
}

export interface MessageDto extends EntityDto<string> {
  content?: string;
  postDate?: string;
  userId?: string;
  userName?: string;
  channelId?: string;
}
