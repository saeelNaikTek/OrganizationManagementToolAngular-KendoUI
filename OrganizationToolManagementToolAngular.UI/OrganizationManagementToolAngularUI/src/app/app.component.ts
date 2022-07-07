import { Component, Input } from '@angular/core';
import { DrawerSelectEvent } from '@progress/kendo-angular-layout';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'OrganizationManagementToolAngularUI';
  public selected = 'Faculty';
  public items: Array<{text: string, icon: string, selected?: boolean} | {separator: boolean}> = [
      { text: 'Faculty', icon: 'k-i-user', selected: true },
      { separator: true },
      { text: 'Card', icon: 'k-i-image' },
      { separator: true },
      { text: 'ExpansionPanel', icon: 'k-i-insert-up' },
      { separator: true },
      { text: 'GridLayout', icon: 'k-i-cells-merge-vertically' },
      { separator: true },
      { text: 'PanelBar', icon: 'k-i-menu' },
      { separator: true },
      { text: 'Splitter', icon: 'k-i-arrows-resizing' },
      { separator: true },
      { text: 'StackLayout', icon: 'k-i-align-justify' },
      { separator: true },
      { text: 'Stepper', icon: 'k-i-list-numbered' },
      { separator: true },
      { text: 'TabStrip', icon: 'k-i-thumbnails-up' },
      { separator: true },
      { text: 'TileLayout', icon: 'k-i-grid' }
  ];

  public onSelect(ev: DrawerSelectEvent): void {
      this.selected = ev.item.text;
  }
}
