import {
  Directive,
  ElementRef,
  EventEmitter,
  HostListener,
  Output,
} from '@angular/core';

@Directive({ selector: '[unselectableRadioBtn]' })
export class UnselectableRadioBtnDirective {
  constructor(private elementRef: ElementRef) {}

  @Output()
  public radioBtnClicked = new EventEmitter<string>();

  @HostListener('click', ['$event.target']) onClick($target: HTMLInputElement) {
    this.radioBtnClicked.emit($target.value);
    this.elementRef.nativeElement
      .querySelector('.mdc-radio__native-control')
      .blur();
  }
}
