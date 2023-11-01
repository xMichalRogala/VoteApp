import { Component, EventEmitter, Output } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  @Output()
  readonly themeChanged = new EventEmitter<boolean>();

  onThemeChanged({ checked }: MatSlideToggleChange) {
    this.themeChanged.emit(checked);
  }
}
