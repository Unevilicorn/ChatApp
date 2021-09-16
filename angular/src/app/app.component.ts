import { Component } from '@angular/core';
import { NavItemsService } from '@abp/ng.theme.shared';
import { eThemeBasicComponents } from '@abp/ng.theme.basic';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent {
  constructor(private navItems: NavItemsService) {
    navItems.removeItem(eThemeBasicComponents.Languages);
  }
}
