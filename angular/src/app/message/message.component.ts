import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { MessageService, MessageDto } from '@proxy/messages';
import { query } from '@angular/animations';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss'],
  providers: [ListService],
})
export class MessageComponent implements OnInit {
  messages = { items: [], totalCount: 0 } as PagedResultDto<MessageDto>;
  userId = '';
  textPlace = null;

  constructor(public readonly list: ListService, private messageService: MessageService) {}

  ngOnInit(): void {
    this.messageService.getCurrentUserId().subscribe(response => {
      this.userId = JSON.parse(response);

      if (!this.userId) {
        return;
      }

      this.list.maxResultCount = 1000;
      const messageStreamCreator = query => this.messageService.getList(query);
      this.list.hookToQuery(messageStreamCreator).subscribe(response => {
        this.messages = response;
      });

      this.textPlace = document.getElementById('textPlace');
      setInterval(this.list.get, 1000);
    });
  }

  toTime(longDate: string): string {
    return new Date(longDate).toLocaleString();
  }
  isYou(otherId: string): boolean {
    return otherId === this.userId;
  }

  public sendData() {
    this.messageService
      .create({
        content: this.textPlace.innerHTML.substring(0, 2000),
        postDate: new Date().toLocalISOString(),
        userId: this.userId,
      })
      .subscribe(() => {
        this.textPlace.innerHTML = '';
        this.list.get();
      });
  }
}
