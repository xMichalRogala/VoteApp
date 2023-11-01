import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'bdm-web-app';

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2
  ) {}

  ngOnInit() {
    this.renderer.setAttribute(this.document.body, 'class', 'theme-light');
  }

  switchTheme(darkChecked: boolean) {
    const themeClass = darkChecked ? 'theme-dark' : 'theme-light';
    this.renderer.setAttribute(this.document.body, 'class', themeClass);
  }
}
